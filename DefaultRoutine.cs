using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;
using Buddy.Coroutines;
using HREngine.Bots;
using log4net;
using Microsoft.Scripting.Hosting;
using Triton.Bot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Data;

//!CompilerOption|AddRef|IronPython.dll
//!CompilerOption|AddRef|IronPython.Modules.dll
//!CompilerOption|AddRef|Microsoft.Scripting.dll
//!CompilerOption|AddRef|Microsoft.Dynamic.dll
//!CompilerOption|AddRef|Microsoft.Scripting.Metadata.dll
using Triton.Game.Mapping;
using Triton.Bot.Logic.Bots.DefaultBot;
using Logger = Triton.Common.LogUtilities.Logger;

namespace HREngine.Bots
{
    public class DefaultRoutine : IRoutine
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();
        private readonly ScriptManager _scriptManager = new ScriptManager();

        private readonly List<Tuple<string, string>> _mulliganRules = new List<Tuple<string, string>>();

        private int dirtyTargetSource = -1;
        private int stopAfterWins = 30;
        private int concedeLvl = 5; // the rank, till you want to concede
        private int dirtytarget = -1;
        private int dirtychoice = -1;
        private string choiceCardId = "";
        DateTime starttime = DateTime.Now;
        bool enemyConcede = false;

        public bool learnmode = false;
        public bool printlearnmode = true;

        Silverfish sf = Silverfish.Instance;
        DefaultBotSettings botset
        {
            get { return DefaultBotSettings.Instance; }
        }
        //uncomment the desired option, or leave it as is to select via the interface
        Behavior behave = new BehaviorControl();
        //Behavior behave = new BehaviorRush();


        public DefaultRoutine()
        {
            // Global rules. Never keep a 4+ minion, unless it's Bolvar Fordragon (paladin).
            _mulliganRules.Add(new Tuple<string, string>("True", "card.Entity.Cost >= 4 and card.Entity.Id != \"GVG_063\""));

            // Never keep Tracking.
            _mulliganRules.Add(new Tuple<string, string>("mulliganData.UserClass == CardClass.HUNTER", "card.Entity.Id == \"DS1_184\""));

            // Example rule for self.
            //_mulliganRules.Add(new Tuple<string, string>("mulliganData.UserClass == CardClass.MAGE", "card.Cost >= 5"));

            // Example rule for opponents.
            //_mulliganRules.Add(new Tuple<string, string>("mulliganData.OpponentClass == CardClass.MAGE", "card.Cost >= 3"));

            // Example rule for matchups.
            //_mulliganRules.Add(new Tuple<string, string>("mulliganData.userClass == CardClass.HUNTER && mulliganData.OpponentClass == CardClass.DRUID", "card.Cost >= 2"));

            bool concede = false;
            bool teststuff = false;
            // set to true, to run a testfile (requires test.txt file in folder where _cardDB.txt file is located)
            bool printstuff = false; // if true, the best board of the tested file is printet stepp by stepp

            Helpfunctions.Instance.ErrorLog("----------------------------");
            Helpfunctions.Instance.ErrorLog("您正在使用的AI版本为" + Silverfish.Instance.versionnumber);
            Helpfunctions.Instance.ErrorLog("----------------------------");

            if (teststuff)
            {
                Ai.Instance.autoTester(printstuff);
            }
        }

        #region Scripting

        private const string BoilerPlateExecute = @"
import sys
sys.stdout=ioproxy

def Execute():
    return bool({0})";

        public delegate void RegisterScriptVariableDelegate(ScriptScope scope);

        public bool GetCondition(string expression, IEnumerable<RegisterScriptVariableDelegate> variables)
        {
            var code = string.Format(BoilerPlateExecute, expression);
            var scope = _scriptManager.Scope;
            var scriptSource = _scriptManager.Engine.CreateScriptSourceFromString(code);
            scope.SetVariable("ioproxy", _scriptManager.IoProxy);
            foreach (var variable in variables)
            {
                variable(scope);
            }
            scriptSource.Execute(scope);
            return scope.GetVariable<Func<bool>>("Execute")();
        }

        public bool VerifyCondition(string expression,
            IEnumerable<string> variables, out Exception ex)
        {
            ex = null;
            try
            {
                var code = string.Format(BoilerPlateExecute, expression);
                var scope = _scriptManager.Scope;
                var scriptSource = _scriptManager.Engine.CreateScriptSourceFromString(code);
                scope.SetVariable("ioproxy", _scriptManager.IoProxy);
                foreach (var variable in variables)
                {
                    scope.SetVariable(variable, new object());
                }
                scriptSource.Compile();
            }
            catch (Exception e)
            {
                ex = e;
                return false;
            }
            return true;
        }

        #endregion

        #region Implementation of IAuthored

        /// <summary> The name of the routine. </summary>
        public string Name
        {
            get { return "策略"; }
        }

        /// <summary> The description of the routine. </summary>
        public string Description
        {
            get { return "炉石兄弟的默认策略."; }
        }

        /// <summary>The author of this routine.</summary>
        public string Author
        {
            get { return "Bossland GmbH"; }
        }

        /// <summary>The version of this routine.</summary>
        public string Version
        {
            get { return "0.0.1.1"; }
        }

        #endregion

        #region Implementation of IBase

        /// <summary>Initializes this routine.</summary>
        public void Initialize()
        {
            _scriptManager.Initialize(null,
                new List<string>
                {
                    "Triton.Game",
                    "Triton.Bot",
                    "Triton.Common",
                    "Triton.Game.Mapping",
                    "Triton.Game.Abstraction"
                });
        }

        /// <summary>Deinitializes this routine.</summary>
        public void Deinitialize()
        {
            _scriptManager.Deinitialize();
        }

        #endregion

        #region Implementation of IRunnable

        /// <summary> The routine start callback. Do any initialization here. </summary>
        public void Start()
        {
            GameEventManager.NewGame += GameEventManagerOnNewGame;
            GameEventManager.GameOver += GameEventManagerOnGameOver;
            GameEventManager.QuestUpdate += GameEventManagerOnQuestUpdate;
            GameEventManager.ArenaRewards += GameEventManagerOnArenaRewards;

            if (Hrtprozis.Instance.settings == null)
            {
                Hrtprozis.Instance.setInstances();
                ComboBreaker.Instance.setInstances();
                PenalityManager.Instance.setInstances();
            }
            behave = sf.getBehaviorByName(DefaultRoutineSettings.Instance.DefaultBehavior);
            foreach (var tuple in _mulliganRules)
            {
                Exception ex;
                if (
                    !VerifyCondition(tuple.Item1, new List<string> {"mulliganData"}, out ex))
                {
                    Log.ErrorFormat("[开始] 发现一个错误的留牌策略为 [{1}]: {0}.", ex,
                        tuple.Item1);
                    BotManager.Stop();
                }

                if (
                    !VerifyCondition(tuple.Item2, new List<string> {"mulliganData", "card"},
                        out ex))
                {
                    Log.ErrorFormat("[开始] 发现一个错误的留牌策略为 [{1}]: {0}.", ex,
                        tuple.Item2);
                    BotManager.Stop();
                }
            }
        }

        /// <summary> The routine tick callback. Do any update logic here. </summary>
        public void Tick()
        {
        }

        /// <summary> The routine stop callback. Do any pre-dispose cleanup here. </summary>
        public void Stop()
        {
            GameEventManager.NewGame -= GameEventManagerOnNewGame;
            GameEventManager.GameOver -= GameEventManagerOnGameOver;
            GameEventManager.QuestUpdate -= GameEventManagerOnQuestUpdate;
            GameEventManager.ArenaRewards -= GameEventManagerOnArenaRewards;
        }

        #endregion

        #region Implementation of IConfigurable

        /// <summary> The routine's settings control. This will be added to the Hearthbuddy Settings tab.</summary>
        public UserControl Control
        {
            get
            {
                using (var fs = new FileStream(@"Routines\DefaultRoutine\SettingsGui.xaml", FileMode.Open))
                {
                    var root = (UserControl) XamlReader.Load(fs);

                    // Your settings binding here.

                    // ArenaPreferredClass1
                    if (
                        !Wpf.SetupComboBoxItemsBinding(root, "ArenaPreferredClass1ComboBox", "AllClasses",
                            BindingMode.OneWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxItemsBinding failed for 'ArenaPreferredClass1ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    if (
                        !Wpf.SetupComboBoxSelectedItemBinding(root, "ArenaPreferredClass1ComboBox",
                            "ArenaPreferredClass1", BindingMode.TwoWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'ArenaPreferredClass1ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // ArenaPreferredClass2
                    if (
                        !Wpf.SetupComboBoxItemsBinding(root, "ArenaPreferredClass2ComboBox", "AllClasses",
                            BindingMode.OneWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxItemsBinding failed for 'ArenaPreferredClass2ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    if (
                        !Wpf.SetupComboBoxSelectedItemBinding(root, "ArenaPreferredClass2ComboBox",
                            "ArenaPreferredClass2", BindingMode.TwoWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'ArenaPreferredClass2ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // ArenaPreferredClass3
                    if (
                        !Wpf.SetupComboBoxItemsBinding(root, "ArenaPreferredClass3ComboBox", "AllClasses",
                            BindingMode.OneWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxItemsBinding failed for 'ArenaPreferredClass3ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    if (
                        !Wpf.SetupComboBoxSelectedItemBinding(root, "ArenaPreferredClass3ComboBox",
                            "ArenaPreferredClass3", BindingMode.TwoWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'ArenaPreferredClass3ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // ArenaPreferredClass4
                    if (
                        !Wpf.SetupComboBoxItemsBinding(root, "ArenaPreferredClass4ComboBox", "AllClasses",
                            BindingMode.OneWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxItemsBinding failed for 'ArenaPreferredClass4ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    if (
                        !Wpf.SetupComboBoxSelectedItemBinding(root, "ArenaPreferredClass4ComboBox",
                            "ArenaPreferredClass4", BindingMode.TwoWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'ArenaPreferredClass4ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // ArenaPreferredClass5
                    if (
                        !Wpf.SetupComboBoxItemsBinding(root, "ArenaPreferredClass5ComboBox", "AllClasses",
                            BindingMode.OneWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxItemsBinding failed for 'ArenaPreferredClass5ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    if (
                        !Wpf.SetupComboBoxSelectedItemBinding(root, "ArenaPreferredClass5ComboBox",
                            "ArenaPreferredClass5", BindingMode.TwoWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'ArenaPreferredClass5ComboBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // defaultBehaviorComboBox1
                    if (
                        !Wpf.SetupComboBoxItemsBinding(root, "defaultBehaviorComboBox1", "AllBehav",
                            BindingMode.OneWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxItemsBinding failed for 'defaultBehaviorComboBox1'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    if (
                        !Wpf.SetupComboBoxSelectedItemBinding(root, "defaultBehaviorComboBox1",
                            "DefaultBehavior", BindingMode.TwoWay, DefaultRoutineSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'defaultBehaviorComboBox1'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    // Your settings event handlers here.

                    return root;
                }
            }
        }

        /// <summary>The settings object. This will be registered in the current configuration.</summary>
        public JsonSettings Settings
        {
            get { return DefaultRoutineSettings.Instance; }
        }

        #endregion

        #region Implementation of IRoutine

        /// <summary>
        /// Sends data to the routine with the associated name.
        /// </summary>
        /// <param name="name">The name of the configuration.</param>
        /// <param name="param">The data passed for the configuration.</param>
        public void SetConfiguration(string name, params object[] param)
        {
        }

        /// <summary>
        /// Requests data from the routine with the associated name.
        /// </summary>
        /// <param name="name">The name of the configuration.</param>
        /// <returns>Data from the routine.</returns>
        public object GetConfiguration(string name)
        {
            return null;
        }

        /// <summary>
        /// The routine's coroutine logic to execute.
        /// </summary>
        /// <param name="type">The requested type of logic to execute.</param>
        /// <param name="context">Data sent to the routine from the bot for the current logic.</param>
        /// <returns>true if logic was executed to handle this type and false otherwise.</returns>
        public async Task<bool> Logic(string type, object context)
        {


            // The bot is requesting mulligan logic.
            if (type == "mulligan")
            {
                await MulliganLogic(context as MulliganData);
                return true;
            }

            // The bot is requesting emote logic.
            if (type == "emote")
            {
                await EmoteLogic(context as EmoteData);
                return true;
            }

            // The bot is requesting our turn logic.
            if (type == "our_turn")
            {
                await OurTurnLogic();
                return true;
            }

            // The bot is requesting opponent turn logic.
            if (type == "opponent_turn")
            {
                await OpponentTurnLogic();
                return true;
            }

	        // The bot is requesting our turn logic.
	        if (type == "our_turn_combat")
	        {
		        await OurTurnCombatLogic();
		        return true;
	        }

	        // The bot is requesting opponent turn logic.
	        if (type == "opponent_turn_combat")
	        {
		        await OpponentTurnCombatLogic();
		        return true;
	        }

			// The bot is requesting arena draft logic.
			if (type == "arena_draft")
            {
                await ArenaDraftLogic(context as ArenaDraftData);
                return true;
            }

            // The bot is requesting quest handling logic.
            if (type == "handle_quests")
            {
                await HandleQuestsLogic(context as QuestData);
                return true;
            }

            // Whatever the current logic type is, this routine doesn't implement it.
            return false;
        }

        #region Mulligan

        private int RandomMulliganThinkTime()
        {
            var random = Client.Random;
            var type = random.Next(0, 100)%4;

            if (type == 0) return random.Next(800, 1200);
            if (type == 1) return random.Next(1200, 2500);
            if (type == 2) return random.Next(2500, 3700);
            return 0;
        }

        /// <summary>
        /// This task implements custom mulligan choosing logic for the bot.
        /// The user is expected to set the Mulligans list elements to true/false
        /// to signal to the bot which cards should/shouldn't be mulliganed.
        /// This task should also implement humanization factors, such as hovering
        /// over cards, or delaying randomly before returning, as the mulligan
        /// process takes place as soon as the task completes.
        /// </summary>
        /// <param name="mulliganData">An object that contains relevant data for the mulligan process.</param>
        /// <returns></returns>
        public async Task MulliganLogic(MulliganData mulliganData)
        {
            if (!botset.AutoConcedeLag && !botset.ForceConcedeAtMulligan)
            {
            Log.InfoFormat("[日志档案:] 开始创建");
            Hrtprozis prozis = Hrtprozis.Instance;
            prozis.clearAllNewGame();
            Silverfish.Instance.setnewLoggFile();
            Log.InfoFormat("[日志档案:] 创建完成");
            }
            Log.InfoFormat("[开局留牌] {0} 对阵 {1}.", mulliganData.UserClass, mulliganData.OpponentClass);
            var count = mulliganData.Cards.Count;

            if (this.behave.BehaviorName() != DefaultRoutineSettings.Instance.DefaultBehavior)
            {
                behave = sf.getBehaviorByName(DefaultRoutineSettings.Instance.DefaultBehavior);
            }
            if (!Mulligan.Instance.getHoldList(mulliganData, this.behave))
            {
                for (var i = 0; i < count; i++)
                {
                    var card = mulliganData.Cards[i];

                    try
                    {
                        foreach (var tuple in _mulliganRules)
                        {
                            if (GetCondition(tuple.Item1,
                                new List<RegisterScriptVariableDelegate>
                            {
                                scope => scope.SetVariable("mulliganData", mulliganData)
                            }))
                            {
                                if (GetCondition(tuple.Item2,
                                    new List<RegisterScriptVariableDelegate>
                                {
                                    scope => scope.SetVariable("mulliganData", mulliganData),
                                    scope => scope.SetVariable("card", card)
                                }))
                                {
                                    mulliganData.Mulligans[i] = true;
                                    Log.InfoFormat(
                                        "[开局留牌] {0} 这张卡片符合自定义留牌规则: [{1}] ({2}).",
                                        card.Entity.Id, tuple.Item2, tuple.Item1);
                                }
                            }
                            else
                            {
                                Log.InfoFormat(
                                    "[开局留牌] 留牌策略检测发现 [{0}] 的规则错误, 所以 [{1}] 的规则不执行.",
                                    tuple.Item1, tuple.Item2);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("[Mulligan] An exception occurred: {0}.", ex);
                        BotManager.Stop();
                        return;
                    }
                }
            }

            var thinkList = new List<KeyValuePair<int, int>>();
            for (var i = 0; i < count; i++)
            {
                thinkList.Add(new KeyValuePair<int, int>(i%count, RandomMulliganThinkTime()));
            }
            thinkList.Shuffle();

            foreach (var entry in thinkList)
            {
                var card = mulliganData.Cards[entry.Key];

                Log.InfoFormat("[开局留牌] 现在开始思考留牌 {0} 时间已经过去 {1} 毫秒.", card.Entity.Id, entry.Value);

                // Instant think time, skip the card.
                if (entry.Value == 0)
                    continue;

                Client.MouseOver(card.InteractPoint);

                await Coroutine.Sleep(entry.Value);
            }
        }

        #endregion

        #region Emote

        /// <summary>
        /// This task implements player emote detection logic for the bot.
        /// </summary>
        /// <param name="data">An object that contains relevant data for the emote event.</param>
        /// <returns></returns>
        public async Task EmoteLogic(EmoteData data)
        {
            Log.InfoFormat("[表情] 使用表情 [{0}].", data.Emote);

            if (data.Emote == EmoteType.GREETINGS)
            {
            }
            else if (data.Emote == EmoteType.WELL_PLAYED)
            {
            }
            else if (data.Emote == EmoteType.OOPS)
            {
            }
            else if (data.Emote == EmoteType.THREATEN)
            {
            }
            else if (data.Emote == EmoteType.THANKS)
            {
            }
            else if (data.Emote == EmoteType.SORRY)
            {
            }
        }

        #endregion

        #region Turn

	    public async Task OurTurnCombatLogic()
	    {
            Log.InfoFormat("[我方回合]");
            await Coroutine.Sleep(555 + makeChoice());
            switch (dirtychoice)
            {
                case 0: TritonHs.ChooseOneClickMiddle(); break;
                case 1: TritonHs.ChooseOneClickLeft(); break;
                case 2: TritonHs.ChooseOneClickRight(); break;
            }

            dirtychoice = -1;
            await Coroutine.Sleep(555);
            Silverfish.Instance.lastpf = null;
            return;
		}

	    public async Task OpponentTurnCombatLogic()
	    {
		    Log.Info("[对手回合]");
	    }

		/// <summary>
		/// Under construction.
		/// </summary>
		/// <returns></returns>
		public async Task OurTurnLogic()
        {
            if (this.behave.BehaviorName() != DefaultRoutineSettings.Instance.DefaultBehavior)
            {
                behave = sf.getBehaviorByName(DefaultRoutineSettings.Instance.DefaultBehavior);
                Silverfish.Instance.lastpf = null;
            }

            if (this.learnmode && (TritonHs.IsInTargetMode() || TritonHs.IsInChoiceMode()))
            {
                await Coroutine.Sleep(50);
                return;
            }

            if (TritonHs.IsInTargetMode())
            {
                if (dirtytarget >= 0)
                {
                    Log.Info("瞄准中...");
                    HSCard source = null;
                    if (dirtyTargetSource == 9000) // 9000 = ability
                    {
                        source = TritonHs.OurHeroPowerCard;
                    }
                    else
                    {
                        source = getEntityWithNumber(dirtyTargetSource);
                    }
                    HSCard target = getEntityWithNumber(dirtytarget);

                    if (target == null)
                    {
                        Log.Error("目标为空...");
                        TritonHs.CancelTargetingMode();
                        return;
                    }

                    dirtytarget = -1;
                    dirtyTargetSource = -1;

                    if (source == null) await TritonHs.DoTarget(target);
                    else await source.DoTarget(target);

                    await Coroutine.Sleep(555);

                    return;
                }

                Log.Error("目标丢失...");
                TritonHs.CancelTargetingMode();
                return;
            }

            if (TritonHs.IsInChoiceMode())
            {
                await Coroutine.Sleep(555 + makeChoice());
                switch (dirtychoice)
                {
                    case 0: TritonHs.ChooseOneClickMiddle(); break;
                    case 1: TritonHs.ChooseOneClickLeft(); break;
                    case 2: TritonHs.ChooseOneClickRight(); break;
                }

                dirtychoice = -1;
                await Coroutine.Sleep(555);
                return;
            }

            bool sleepRetry = false;
            bool templearn = Silverfish.Instance.updateEverything(behave, 0, out sleepRetry);
            if (sleepRetry)
            {
                Log.Error("[AI] 随从没能动起来，再试一次...");
                await Coroutine.Sleep(500);
                templearn = Silverfish.Instance.updateEverything(behave, 1, out sleepRetry);
            }

            if (templearn == true) this.printlearnmode = true;

            if (this.learnmode)
            {
                if (this.printlearnmode)
                {
                    Ai.Instance.simmulateWholeTurnandPrint();
                }
                this.printlearnmode = false;

                //do nothing
                await Coroutine.Sleep(50);
                return;
            }

            var moveTodo = Ai.Instance.bestmove;
            if (moveTodo == null || moveTodo.actionType == actionEnum.endturn || Ai.Instance.bestmoveValue < -9999)
            {
                bool doEndTurn = false;
                bool doConcede = false;
                if (Ai.Instance.bestmoveValue > -10000) doEndTurn = true;
                else if (HREngine.Bots.Settings.Instance.concedeMode != 0) doConcede = true;
                else
                {
                    if (new Playfield().ownHeroHasDirectLethal())
                    {
                        Playfield lastChancePl = Ai.Instance.bestplay;
                        bool lastChance = false;
                        if (lastChancePl.owncarddraw > 0)
                        {
                            foreach (Handmanager.Handcard hc in lastChancePl.owncards)
                            {
                                if (hc.card.CardId == Chireiden.Silverfish.SimCard.None) lastChance = true;
                            }
                            if (!lastChance) doConcede = true;
                        }
                        else doConcede = true;

                        if (doConcede)
                        {
                            foreach (Minion m in lastChancePl.ownMinions)
                            {
                                if (!m.playedThisTurn) continue;
                                switch (m.handcard.card.CardId)
                                {
                                    case CardIds.Collectible.Neutral.Cthun: lastChance = true; break;
                                    case CardIds.Collectible.Neutral.NzothTheCorruptor: lastChance = true; break;
                                    case CardIds.Collectible.Neutral.YoggSaronHopesEnd: lastChance = true; break;
                                    case CardIds.Collectible.Neutral.SirFinleyMrrgglton: lastChance = true; break;
                                    case CardIds.Collectible.Neutral.RagnarosTheFirelord: if (lastChancePl.enemyHero.Hp < 9) lastChance = true; break;
                                    case CardIds.Collectible.Neutral.BaronGeddon: if (lastChancePl.enemyHero.Hp < 3) lastChance = true; break;
                                }
                            }
                        }
                        if (lastChance) doConcede = false;
                    }
                    else if (moveTodo == null || moveTodo.actionType == actionEnum.endturn) doEndTurn = true;
                }
                if (doEndTurn)
                {
                    Helpfunctions.Instance.ErrorLog("回合结束");
                    await TritonHs.EndTurn();
                    return;
                }
                else if (doConcede)
                {
                    Helpfunctions.Instance.ErrorLog("我方败局已定. 投降...");
                    Helpfunctions.Instance.logg("投降... 败局已定###############################################");
                    TritonHs.Concede(true);
                    return;
                }
            }
            Helpfunctions.Instance.ErrorLog("开始行动");
            if (moveTodo == null)
            {
                Helpfunctions.Instance.ErrorLog("实在支不出招啦. 结束当前回合");
                await TritonHs.EndTurn();
                return;
            }

            //play the move#########################################################################

            {
                moveTodo.print();

                //play a card form hand
                if (moveTodo.actionType == actionEnum.playcard)
                {
                    Questmanager.Instance.updatePlayedCardFromHand(moveTodo.card);
                    HSCard cardtoplay = getCardWithNumber(moveTodo.card.entity);
                    if (cardtoplay == null)
                    {
                        Helpfunctions.Instance.ErrorLog("[提示] 实在支不出招啦");
                        return;
                    }
                    if (moveTodo.target != null)
                    {
                        HSCard target = getEntityWithNumber(moveTodo.target.entitiyID);
                        if (target != null)
                        {
                            Helpfunctions.Instance.ErrorLog("使用: " + cardtoplay.Name + " (" + cardtoplay.EntityId + ") 瞄准: " + target.Name + " (" + target.EntityId + ")");
                            Helpfunctions.Instance.logg("使用: " + cardtoplay.Name + " (" + cardtoplay.EntityId + ") 瞄准: " + target.Name + " (" + target.EntityId + ") 抉择: " + moveTodo.druidchoice);
						    if (moveTodo.druidchoice >= 1)
                            {
                                dirtytarget = moveTodo.target.entitiyID;
                                dirtychoice = moveTodo.druidchoice; //1=leftcard, 2= rightcard
                                choiceCardId = moveTodo.card.card.CardId.ToString();
                            }

                            //safe targeting stuff for hsbuddy
                            dirtyTargetSource = moveTodo.card.entity;
                            dirtytarget = moveTodo.target.entitiyID;

                            await cardtoplay.Pickup();

                            if (moveTodo.card.card.Type == CardType.MOB)
                            {
                                await cardtoplay.UseAt(moveTodo.place);
                            }
                            else if (moveTodo.card.card.Type == CardType.WEAPON) // This fixes perdition's blade
                            {
                                await cardtoplay.UseOn(target.Card);
                            }
                            else if (moveTodo.card.card.Type == CardType.SPELL)
                            {
                                await cardtoplay.UseOn(target.Card);
                            }
                            else
                            {
                                await cardtoplay.UseOn(target.Card);
                            }
                        }
                        else
                        {
                            Helpfunctions.Instance.ErrorLog("[AI] 目标丢失，再试一次...");
                            Helpfunctions.Instance.logg("[AI] 目标 " + moveTodo.target.entitiyID + "丢失. 再试一次...");
                        }
                        await Coroutine.Sleep(500);

                        return;
                    }

                    Helpfunctions.Instance.ErrorLog("使用: " + cardtoplay.Name + " (" + cardtoplay.EntityId + ") 暂时没有目标");
                    Helpfunctions.Instance.logg("使用: " + cardtoplay.Name + " (" + cardtoplay.EntityId + ") 抉择: " + moveTodo.druidchoice);
                    if (moveTodo.druidchoice >= 1)
                    {
                        dirtychoice = moveTodo.druidchoice; //1=leftcard, 2= rightcard
                        choiceCardId = moveTodo.card.card.CardId.ToString();
                    }

                    dirtyTargetSource = -1;
                    dirtytarget = -1;

                    await cardtoplay.Pickup();

                    if (moveTodo.card.card.Type == CardType.MOB)
                    {
                        await cardtoplay.UseAt(moveTodo.place);
                    }
                    else
                    {
                        await cardtoplay.Use();
                    }
                    await Coroutine.Sleep(500);

                    return;
                }

                //attack with minion
                if (moveTodo.actionType == actionEnum.attackWithMinion)
                {
                    HSCard attacker = getEntityWithNumber(moveTodo.own.entitiyID);
                    HSCard target = getEntityWithNumber(moveTodo.target.entitiyID);
                    if (attacker != null)
                    {
                        if (target != null)
                        {
                            Helpfunctions.Instance.ErrorLog("随从攻击: " + attacker.Name + " 目标为: " + target.Name);
                            Helpfunctions.Instance.logg("随从攻击: " + attacker.Name + " 目标为: " + target.Name);


                            await attacker.DoAttack(target);

                        }
                        else
                        {
                            Helpfunctions.Instance.ErrorLog("[AI] 目标丢失，再次重试...");
                            Helpfunctions.Instance.logg("[AI] 目标 " + moveTodo.target.entitiyID + "丢失. 再次重试...");
                        }
                    }
                    else
                    {
                        Helpfunctions.Instance.ErrorLog("[AI] 攻击失败，再次重试...");
                        Helpfunctions.Instance.logg("[AI] 进攻 " + moveTodo.own.entitiyID + " 失败.再次重试...");
                    }
                    await Coroutine.Sleep(250);
                    return;
                }
                //attack with hero
                if (moveTodo.actionType == actionEnum.attackWithHero)
                {
                    HSCard attacker = getEntityWithNumber(moveTodo.own.entitiyID);
                    HSCard target = getEntityWithNumber(moveTodo.target.entitiyID);
                    if (attacker != null)
                    {
                        if (target != null)
                        {
                            dirtytarget = moveTodo.target.entitiyID;
                            Helpfunctions.Instance.ErrorLog("英雄攻击: " + attacker.Name + " 目标为: " + target.Name);
                            Helpfunctions.Instance.logg("英雄攻击: " + attacker.Name + " 目标为: " + target.Name);

                            //safe targeting stuff for hsbuddy
                            dirtyTargetSource = moveTodo.own.entitiyID;
                            dirtytarget = moveTodo.target.entitiyID;
                            await attacker.DoAttack(target);
                        }
                        else
                        {
                            Helpfunctions.Instance.ErrorLog("[AI] 英雄攻击目标丢失，再次重试...");
                            Helpfunctions.Instance.logg("[AI] 英雄攻击目标 " + moveTodo.target.entitiyID + "丢失，再次重试...");
                        }
                    }
                    else
                    {
                        Helpfunctions.Instance.ErrorLog("[AI] 英雄攻击失败，再次重试...");
                        Helpfunctions.Instance.logg("[AI] 英雄攻击 " + moveTodo.own.entitiyID + " 失败，再次重试...");
                    }
				    await Coroutine.Sleep(250);
                    return;
                }

                //use ability
                if (moveTodo.actionType == actionEnum.useHeroPower)
                {
                    HSCard cardtoplay = TritonHs.OurHeroPowerCard;

                    if (moveTodo.target != null)
                    {
                        HSCard target = getEntityWithNumber(moveTodo.target.entitiyID);
                        if (target != null)
                        {
                            Helpfunctions.Instance.ErrorLog("使用英雄技能: " + cardtoplay.Name + " 目标为 " + target.Name);
                            Helpfunctions.Instance.logg("使用英雄技能: " + cardtoplay.Name + " 目标为 " + target.Name + (moveTodo.druidchoice > 0 ? (" 抉择: " + moveTodo.druidchoice) : ""));
                            if (moveTodo.druidchoice > 0)
                            {
                                dirtytarget = moveTodo.target.entitiyID;
                                dirtychoice = moveTodo.druidchoice; //1=leftcard, 2= rightcard
                                choiceCardId = moveTodo.card.card.CardId.ToString();
                            }

                            dirtyTargetSource = 9000;
                            dirtytarget = moveTodo.target.entitiyID;

                            await cardtoplay.Pickup();
                            await cardtoplay.UseOn(target.Card);
                        }
                        else
                        {
                            Helpfunctions.Instance.ErrorLog("[AI] 目标丢失，再次重试...");
                            Helpfunctions.Instance.logg("[AI] 目标 " + moveTodo.target.entitiyID + "丢失. 再次重试...");
                        }
                        await Coroutine.Sleep(500);
                    }
                    else
                    {
                        Helpfunctions.Instance.ErrorLog("使用英雄技能: " + cardtoplay.Name + " 暂时没有目标");
                        Helpfunctions.Instance.logg("使用英雄技能: " + cardtoplay.Name + " 暂时没有目标" + (moveTodo.druidchoice > 0 ? (" 抉择: " + moveTodo.druidchoice) : ""));

                        if (moveTodo.druidchoice >= 1)
                        {
                            dirtychoice = moveTodo.druidchoice; //1=leftcard, 2= rightcard
                            choiceCardId = moveTodo.card.card.CardId.ToString();
                        }

                        dirtyTargetSource = -1;
                        dirtytarget = -1;

                        await cardtoplay.Pickup();
                    }

                    return;
                }
            }

            await TritonHs.EndTurn();
        }

        private int makeChoice()
        {
            if (dirtychoice < 1)
            {
                var ccm = ChoiceCardMgr.Get();
                var lscc = ccm.m_lastShownChoiceState;
                GAME_TAG choiceMode = GAME_TAG.CHOOSE_ONE;
                int sourceEntityId = -1;
                Chireiden.Silverfish.SimCard sourceEntityCId = Chireiden.Silverfish.SimCard.None;
                if (lscc != null)
                {
                    sourceEntityId = lscc.m_sourceEntityId;
                    Entity entity = GameState.Get().GetEntity(lscc.m_sourceEntityId);
                    sourceEntityCId = (entity.GetCardId());
                    if (entity != null)
                    {
                        var sourceCard = entity.GetCard();
                        if (sourceCard != null)
                        {
                            if (sourceCard.GetEntity().HasReferencedTag(GAME_TAG.DISCOVER))
                            {
                                choiceMode = GAME_TAG.DISCOVER;
                                dirtychoice = -1;
                            }
                            else if (sourceCard.GetEntity().HasReferencedTag(GAME_TAG.ADAPT))
                            {
                                choiceMode = GAME_TAG.ADAPT;
                                dirtychoice = -1;
                            }
                        }
                    }
                }

                Ai ai = Ai.Instance;
                List<Handmanager.Handcard> discoverCards = new List<Handmanager.Handcard>();
                float bestDiscoverValue = -2000000;
                var choiceCardMgr = ChoiceCardMgr.Get();
                var cards = choiceCardMgr.GetFriendlyCards();

                for (int i = 0; i < cards.Count; i++)
                {
                    var hc = new Handmanager.Handcard();
                    hc.card = ((cards[i].GetCardId()));
                    hc.position = 100 + i;
                    hc.entity = cards[i].GetEntityId();
                    hc.manacost = hc.card.calculateManaCost(ai.nextMoveGuess);
                    discoverCards.Add(hc);
                }

                int sirFinleyChoice = -1;
                if (ai.bestmove == null) Log.ErrorFormat("[提示] 没有获得卡牌数据");
                else if (ai.bestmove.actionType == actionEnum.playcard && ai.bestmove.card.card.CardId == CardIds.Collectible.Neutral.SirFinleyMrrgglton)
                {
                    sirFinleyChoice = ai.botBase.getSirFinleyPriority(discoverCards);
                }
                if (choiceMode != GAME_TAG.DISCOVER) sirFinleyChoice = -1;

                DateTime tmp = DateTime.Now;
                int discoverCardsCount = discoverCards.Count;
                if (sirFinleyChoice != -1) dirtychoice = sirFinleyChoice;
                else
                {
                    int dirtyTwoTurnSim = ai.mainTurnSimulator.getSecondTurnSimu();
                    ai.mainTurnSimulator.setSecondTurnSimu(true, 50);
                    using (TritonHs.Memory.ReleaseFrame(true))
                    {
                        Playfield testPl = new Playfield();
                        Playfield basePlf = new Playfield(ai.nextMoveGuess);
                        for (int i = 0; i < discoverCardsCount; i++)
                        {
                            Playfield tmpPlf = new Playfield(basePlf);
                            tmpPlf.isLethalCheck = false;
                            float bestval = bestDiscoverValue;
                            switch (choiceMode)
                            {
                                case GAME_TAG.DISCOVER:
                                    switch (ai.bestmove.card.card.CardId)
                                    {
                                        case CardIds.Collectible.Priest.EternalServitude:
                                        case CardIds.Collectible.Priest.FreeFromAmber:
                                            Minion m = tmpPlf.createNewMinion(discoverCards[i], tmpPlf.ownMinions.Count, true);
                                            tmpPlf.ownMinions[tmpPlf.ownMinions.Count - 1] = m;
                                            break;
                                        default:
                                            tmpPlf.owncards[tmpPlf.owncards.Count - 1] = discoverCards[i];
                                            break;
                                    }
                                    bestval = ai.mainTurnSimulator.doallmoves(tmpPlf);
                                    if (discoverCards[i].card.CardId == CardIds.Collectible.Warlock.BloodImp) bestval -= 20;
                                    break;
                                case GAME_TAG.ADAPT:
                                    bool found = false;
                                    foreach (Minion m in tmpPlf.ownMinions)
                                    {
                                        if (m.entitiyID == sourceEntityId)
                                        {
                                            bool forbidden = false;
                                            switch (discoverCards[i].card.CardId)
                                            {
                                                case CardIds.NonCollectible.Neutral.LiquidMembraneToken1: if (m.cantBeTargetedBySpellsOrHeroPowers) forbidden = true; break;
                                                case CardIds.NonCollectible.Neutral.MassiveToken1: if (m.taunt) forbidden = true; break;
                                                case CardIds.NonCollectible.Neutral.LightningSpeedToken1: if (m.windfury) forbidden = true; break;
                                                case CardIds.NonCollectible.Neutral.CracklingShieldToken1: if (m.divineshild) forbidden = true; break;
                                                case CardIds.NonCollectible.Neutral.ShroudingMistToken1: if (m.stealth) forbidden = true; break;
                                                case CardIds.NonCollectible.Neutral.PoisonSpitToken1: if (m.poisonous) forbidden = true; break;
                                            }
                                            if (forbidden) bestval = -2000000;
                                            else
                                            {
                                                discoverCards[i].card.Simulator.onCardPlay(tmpPlf, true, m, 0);
                                                bestval = ai.mainTurnSimulator.doallmoves(tmpPlf);
                                            }
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (!found) Log.ErrorFormat("[AI] sourceEntityId is missing");
                                    break;
                            }
                            if (bestDiscoverValue <= bestval)
                            {
                                bestDiscoverValue = bestval;
                                dirtychoice = i;
                            }
                        }
                    }
                    ai.mainTurnSimulator.setSecondTurnSimu(true, dirtyTwoTurnSim);
                }
                if (sourceEntityCId == CardIds.Collectible.Priest.CuriousGlimmerroot) dirtychoice = new Random().Next(0, 2);
                if (dirtychoice == 0) dirtychoice = 1;
                else if (dirtychoice == 1) dirtychoice = 0;
                int ttf = (int)(DateTime.Now - tmp).TotalMilliseconds;
                Helpfunctions.Instance.logg("发现卡牌: " + dirtychoice + (discoverCardsCount > 1 ? " " + discoverCards[1].card.CardId : "") + (discoverCardsCount > 0 ? " " + discoverCards[0].card.CardId : "") + (discoverCardsCount > 2 ? " " + discoverCards[2].card.CardId : ""));
                if (ttf < 3000) return (new Random().Next(ttf < 1300 ? 1300 - ttf : 0, 3100 - ttf));
            }
            else
            {
                Helpfunctions.Instance.logg("选择这张卡牌: " + dirtychoice);
                return (new Random().Next(1100, 3200));
            }
            return 0;
        }

        /// <summary>
        /// Under construction.
        /// </summary>
        /// <returns></returns>
        public async Task OpponentTurnLogic()
        {
            Log.InfoFormat("[对手回合]");


        }

        #endregion

        #region ArenaDraft

        /// <summary>
        /// Under construction.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task ArenaDraftLogic(ArenaDraftData data)
        {
            Log.InfoFormat("[ArenaDraft]");

            // We don't have a hero yet, so choose one.
            if (data.Hero == null)
            {
                Log.InfoFormat("[ArenaDraft] Hero: [{0} ({3}) | {1} ({4}) | {2} ({5})].",
                    data.Choices[0].EntityDef.CardId, data.Choices[1].EntityDef.CardId, data.Choices[2].EntityDef.CardId,
                    data.Choices[0].EntityDef.Name, data.Choices[1].EntityDef.Name, data.Choices[2].EntityDef.Name);

                // Quest support logic!
                var questIds = TritonHs.CurrentQuests.Select(q => q.Id).ToList();
                foreach (var choice in data.Choices)
                {
                    var @class = choice.EntityDef.Class;
                    foreach (var questId in questIds)
                    {
                        if (TritonHs.IsQuestForClass(questId, @class))
                        {
                            data.Selection = choice;
                            Log.InfoFormat(
                                "[ArenaDraft] Choosing hero \"{0}\" because it matches a current quest.",
                                data.Selection.EntityDef.Name);
                            return;
                        }
                    }
                }

                // TODO: I'm sure there's a better way to do this, but w/e, no time to waste right now.

                // #1
                foreach (var choice in data.Choices)
                {
                    if ((CardClass)choice.EntityDef.Class == DefaultRoutineSettings.Instance.ArenaPreferredClass1)
                    {
                        data.Selection = choice;
                        Log.InfoFormat(
                            "[ArenaDraft] Choosing hero \"{0}\" because it matches the first preferred arena class.",
                            data.Selection.EntityDef.Name);
                        return;
                    }
                }

                // #2
                foreach (var choice in data.Choices)
                {
                    if ((CardClass)choice.EntityDef.Class == DefaultRoutineSettings.Instance.ArenaPreferredClass2)
                    {
                        data.Selection = choice;
                        Log.InfoFormat(
                            "[ArenaDraft] Choosing hero \"{0}\" because it matches the second preferred arena class.",
                            data.Selection.EntityDef.Name);
                        return;
                    }
                }

                // #3
                foreach (var choice in data.Choices)
                {
                    if ((CardClass)choice.EntityDef.Class == DefaultRoutineSettings.Instance.ArenaPreferredClass3)
                    {
                        data.Selection = choice;
                        Log.InfoFormat(
                            "[ArenaDraft] Choosing hero \"{0}\" because it matches the third preferred arena class.",
                            data.Selection.EntityDef.Name);
                        return;
                    }
                }

                // #4
                foreach (var choice in data.Choices)
                {
                    if ((CardClass)choice.EntityDef.Class == DefaultRoutineSettings.Instance.ArenaPreferredClass4)
                    {
                        data.Selection = choice;
                        Log.InfoFormat(
                            "[ArenaDraft] Choosing hero \"{0}\" because it matches the fourth preferred arena class.",
                            data.Selection.EntityDef.Name);
                        return;
                    }
                }

                // #5
                foreach (var choice in data.Choices)
                {
                    if ((CardClass)choice.EntityDef.Class == DefaultRoutineSettings.Instance.ArenaPreferredClass5)
                    {
                        data.Selection = choice;
                        Log.InfoFormat(
                            "[ArenaDraft] Choosing hero \"{0}\" because it matches the fifth preferred arena class.",
                            data.Selection.EntityDef.Name);
                        return;
                    }
                }

                // Choose a random hero.
                data.RandomSelection();

                Log.InfoFormat(
                    "[ArenaDraft] Choosing hero \"{0}\" because no other preferred arena classes were available.",
                    data.Selection.EntityDef.Name);

                return;
            }

            // Normal card choices.
            Log.InfoFormat("[ArenaDraft] Card: [{0} ({3}) | {1} ({4}) | {2} ({5})].", data.Choices[0].EntityDef.CardId,
                data.Choices[1].EntityDef.CardId, data.Choices[2].EntityDef.CardId, data.Choices[0].EntityDef.Name,
                data.Choices[1].EntityDef.Name, data.Choices[2].EntityDef.Name);

            var actor =
                data.Choices.Where(c => ArenavaluesReader.Get.ArenaValues.ContainsKey(c.EntityDef.CardId))
                    .OrderByDescending(c => ArenavaluesReader.Get.ArenaValues[c.EntityDef.CardId]).FirstOrDefault();
            if (actor != null)
            {
                data.Selection = actor;
            }
            else
            {
                data.RandomSelection();
            }
        }

        #endregion

        #region Handle Quests

        /// <summary>
        /// Under construction.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task HandleQuestsLogic(QuestData data)
        {
            Log.InfoFormat("[处理日常任务]");

            // Loop though all quest tiles.
            foreach (var questTile in data.QuestTiles)
            {
                // If we can't cancel a quest, we shouldn't try to.
                if (questTile.IsCancelable)
                {
	                if (DefaultRoutineSettings.Instance.QuestIdsToCancel.Contains(questTile.Achievement.Id))
	                {
						// Mark the quest tile to be canceled.
						questTile.ShouldCancel = true;

                        StringBuilder questsInfo = new StringBuilder("", 1000);
                        questsInfo.Append("[处理日常任务] 任务列表: ");
                        int qNum = data.QuestTiles.Count;
                        for (int i = 0; i < qNum; i++ )
                        {
                            var q = data.QuestTiles[i].Achievement;
                            if (q.RewardData.Count > 0)
                            {
                                questsInfo.Append("[").Append(q.RewardData[0].Count).Append("x ").Append(q.RewardData[0].Type).Append("] ");
                            }
                            questsInfo.Append(q.Name);
                            if (i < qNum - 1) questsInfo.Append(", ");
                        }
                        questsInfo.Append(". 尝试取消任务: ").Append(questTile.Achievement.Name);
                        Log.InfoFormat(questsInfo.ToString());
                        await Coroutine.Sleep(new Random().Next(4000, 8000));
						return;
					}
                }
                else if (DefaultRoutineSettings.Instance.QuestIdsToCancel.Count > 0)
                {
                    Log.InfoFormat("取消任务失败.");
                }
            }
        }

        #endregion

        #endregion

        #region Override of Object

        /// <summary>
        /// ToString override.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + ": " + Description;
        }

        #endregion

        private void GameEventManagerOnGameOver(object sender, GameOverEventArgs gameOverEventArgs)
        {
            Log.InfoFormat("[游戏结束] {0}{2} => {1}.", gameOverEventArgs.Result,
                GameEventManager.Instance.LastGamePresenceStatus, gameOverEventArgs.Conceded ? " [conceded]" : "");
        }

        private void GameEventManagerOnNewGame(object sender, NewGameEventArgs newGameEventArgs)
        {

        }

        private void GameEventManagerOnQuestUpdate(object sender, QuestUpdateEventArgs questUpdateEventArgs)
        {
            Log.InfoFormat("[任务刷新]");
            foreach (var quest in TritonHs.CurrentQuests)
            {
                Log.InfoFormat("[任务刷新][{0}]{1}: {2} ({3} / {4}) [{6}x {5}]", quest.Id, quest.Name, quest.Description, quest.CurProgress,
                    quest.MaxProgress, quest.RewardData[0].Type, quest.RewardData[0].Count);
            }
        }

        private void GameEventManagerOnArenaRewards(object sender, ArenaRewardsEventArgs arenaRewardsEventArgs)
        {
            Log.InfoFormat("[竞技场奖励]");
            foreach (var reward in arenaRewardsEventArgs.Rewards)
            {
                Log.InfoFormat("[竞技场奖励] {1}x {0}.", reward.Type, reward.Count);
            }
        }

        private HSCard getEntityWithNumber(int number)
        {
            foreach (HSCard e in getallEntitys())
            {
                if (number == e.EntityId) return e;
            }
            return null;
        }

        private HSCard getCardWithNumber(int number)
        {
            foreach (HSCard e in getallHandCards())
            {
                if (number == e.EntityId) return e;
            }
            return null;
        }

        private List<HSCard> getallEntitys()
        {
            var result = new List<HSCard>();
            HSCard ownhero = TritonHs.OurHero;
            HSCard enemyhero = TritonHs.EnemyHero;
            HSCard ownHeroAbility = TritonHs.OurHeroPowerCard;
            List<HSCard> list2 = TritonHs.GetCards(CardZone.Battlefield, true);
            List<HSCard> list3 = TritonHs.GetCards(CardZone.Battlefield, false);

            result.Add(ownhero);
            result.Add(enemyhero);
            result.Add(ownHeroAbility);

            result.AddRange(list2);
            result.AddRange(list3);

            return result;
        }

        private List<HSCard> getallHandCards()
        {
            List<HSCard> list = TritonHs.GetCards(CardZone.Hand, true);
            return list;
        }
    }
}
