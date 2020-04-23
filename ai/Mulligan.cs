using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Chireiden.Silverfish;
using HearthDb.Enums;
using log4net;
using Triton.Common.LogUtilities;
using Triton.Game.Data;

namespace HREngine.Bots
{
    /*
This programm allows:
    (lowest priority)
    -Hold all cards that cost less than XXX (manarule)
    (average priority)
    -Hold defined cards (possible to select 1 or 2 cards)
    -Discard defined card (all cards)
    (high priority)
    -Creating rules that allow to Discard (all) cards, depending on the presence of other cards.
    (highest priority)
    -Creating rules that allow to Hold 1 or 2 cards, depending on the presence of other cards.
    -Support different sets of rules for different behaviors.

as well as

    -Can create rules like: if I have a coin, then ...
    -Can create rules for different pairs of ownHero-enemyHero (any or all).
    -It allowed the simultaneous existence of rules with different priorities for the same card
     with the same hero pairs (i.e. possible 3 rules at the same time).
     */

    public class Mulligan
    {
        string pathToMulligan = "";
        public bool mulliganRulesLoaded;
        Dictionary<string, string> MulliganRules = new Dictionary<string, string>();
        Dictionary<string, Dictionary<string, string>> MulliganRulesDB = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<SimCard, string> MulliganRulesManual = new Dictionary<SimCard, string>();
        List<CardIDEntity> cards = new List<CardIDEntity>();
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        public class CardIDEntity
        {
            public SimCard id = SimCard.None;
            public int entitiy;
            public int hold;
            public int holdByRule;
            public int holdByManarule = 1;
            public string holdReason = "";

            public CardIDEntity(string id_string, int entt)
            {
                this.id = id_string;
                this.entitiy = entt;
            }
        }


        private static Mulligan instance;

        public static Mulligan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Mulligan();
                }

                return instance;
            }
        }

        private Mulligan()
        {
        }

        private void readRules(string behavName)
        {
            if (this.MulliganRulesDB.ContainsKey(behavName))
            {
                this.MulliganRules = this.MulliganRulesDB[behavName];
                this.mulliganRulesLoaded = true;
                return;
            }

            if (!Silverfish.Instance.BehaviorPath.ContainsKey(behavName))
            {
                Helpfunctions.Instance.ErrorLog($"{behavName}: no special mulligan.");
                return;
            }

            this.pathToMulligan = Path.Combine(Silverfish.Instance.BehaviorPath[behavName], "_mulligan.txt");

            if (!File.Exists(this.pathToMulligan))
            {
                Helpfunctions.Instance.ErrorLog($"{behavName}: no special mulligan.");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(this.pathToMulligan);
                this.MulliganRules.Clear();
                foreach (var s in lines)
                {
                    if (s == "" || s == null)
                    {
                        continue;
                    }

                    if (s.StartsWith("//"))
                    {
                        continue;
                    }

                    var oneRule = s.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);

                    var tempKey = oneRule[0].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                    var tempValue = oneRule[1].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                    var MullRuleKey = this.joinSomeTxt(tempKey[0], ";", tempKey[1], ";", tempKey[2], ";", tempValue[1] != "/" ? "1" : "0");
                    var MullRuleValue = this.joinSomeTxt(tempKey[3], ";", tempValue[0], ";", tempValue[1]);

                    if (this.MulliganRules.ContainsKey(MullRuleKey))
                    {
                        this.MulliganRules[MullRuleKey] = MullRuleValue;
                    }
                    else
                    {
                        this.MulliganRules.Add(MullRuleKey, MullRuleValue);
                    }
                }
            }
            catch (Exception ee)
            {
                Helpfunctions.Instance.ErrorLog("[开局留牌] 留牌文件_mulligan.txt读取错误. 只能应用默认配置.");
                return;
            }

            Helpfunctions.Instance.ErrorLog($"[开局留牌] 读取规则—— {behavName}");
            this.validateRule(behavName);
        }

        private void validateRule(string behavName)
        {
            var rejectedRule = new List<string>();
            var repairedRules = 0;
            var MulliganRulesTmp = new Dictionary<string, string>();

            foreach (var oneRule in this.MulliganRules)
            {
                var ruleKey = oneRule.Key.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                var ruleValue = oneRule.Value.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                var ruleValueOne = oneRule.Value;

                if (ruleKey.Length != 4 || ruleValue.Length != 3)
                {
                    rejectedRule.Add(this.getClearRule(oneRule.Key));
                    continue;
                }

                if (ruleKey[0] != ruleKey[0])
                {
                    rejectedRule.Add(this.getClearRule(oneRule.Key));
                    continue;
                }

                if (ruleKey[1] != ruleKey[1])
                {
                    rejectedRule.Add(this.getClearRule(oneRule.Key));
                    continue;
                }

                if (ruleKey[2] != ruleKey[2])
                {
                    rejectedRule.Add(this.getClearRule(oneRule.Key));
                    continue;
                }

                if (ruleValue[0] != "Hold" && ruleValue[0] != "Discard")
                {
                    rejectedRule.Add(this.getClearRule(oneRule.Key));
                    continue;
                }

                try
                {
                    Convert.ToInt32(ruleValue[1]);
                }
                catch (Exception eee)
                {
                    rejectedRule.Add(this.getClearRule(oneRule.Key));
                    continue;
                }

                if (ruleValue[2] != "/")
                {
                    if (ruleValue[2].Length < 4) // if lenght < 4 then it a manarule
                    {
                        var manaRule = 4;
                        try
                        {
                            manaRule = Convert.ToInt32(ruleValue[2]);
                        }
                        catch { }

                        if (manaRule < 0)
                        {
                            manaRule = 0;
                        }
                        else if (manaRule > 100)
                        {
                            manaRule = 100;
                        }

                        var tmpSB = new StringBuilder(ruleValue[0], 500);
                        tmpSB.Append(";").Append(ruleValue[1]).Append(";").Append(manaRule);
                        ruleValueOne = tmpSB.ToString();
                    }
                    else
                    {
                        var wasBreak = false;
                        var addedCards = ruleValue[2].Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
                        var MulliganRulesManualTmp = new Dictionary<SimCard, string>();
                        foreach (var s in addedCards)
                        {
                            SimCard tempID = s;
                            if (s != tempID.ToString())
                            {
                                rejectedRule.Add(this.getClearRule(oneRule.Key));
                                wasBreak = true;
                                break;
                            }

                            if (MulliganRulesManualTmp.ContainsKey(tempID))
                            {
                                repairedRules++;
                            }
                            else
                            {
                                MulliganRulesManualTmp.Add(tempID, "");
                            }
                        }

                        if (wasBreak)
                        {
                            continue;
                        }

                        var tmpSB = new StringBuilder(ruleValue[0], 500);
                        tmpSB.Append(";").Append(ruleValue[1]).Append(";");
                        for (var i = 0; i < MulliganRulesManualTmp.Count; i++)
                        {
                            if (i + 1 == MulliganRulesManualTmp.Count)
                            {
                                break;
                            }

                            tmpSB.Append(MulliganRulesManualTmp.ElementAt(i).Key.ToString()).Append("/");
                        }

                        tmpSB.Append(MulliganRulesManualTmp.ElementAt(MulliganRulesManualTmp.Count - 1).Key.ToString());
                        ruleValueOne = tmpSB.ToString();
                    }
                }

                MulliganRulesTmp.Add(oneRule.Key, ruleValueOne);
            }

            if (rejectedRule.Count > 0)
            {
                Helpfunctions.Instance.ErrorLog("[开局留牌] 弃掉卡牌的规则列表:");
                foreach (var tmp in rejectedRule)
                {
                    Helpfunctions.Instance.ErrorLog(tmp);
                }

                Helpfunctions.Instance.ErrorLog("[开局留牌] 关闭规则列表.");
            }

            if (repairedRules > 0)
            {
                Helpfunctions.Instance.ErrorLog($"{repairedRules} repaired rules");
            }

            this.MulliganRules.Clear();

            foreach (var oneRule in MulliganRulesTmp)
            {
                this.MulliganRules.Add(oneRule.Key, oneRule.Value);
            }

            Helpfunctions.Instance.ErrorLog(
                $"[开局留牌] {(this.MulliganRules.Count > 0 ? this.MulliganRules.Count + " 读取留牌规则成功" : "并没有特殊的规则.")}");
            this.mulliganRulesLoaded = true;
            if (behavName == "") //oldCompatibility
            {
                this.MulliganRulesDB.Add("控场模式", new Dictionary<string, string>(this.MulliganRules));
                this.MulliganRulesDB.Add("怼脸模式", new Dictionary<string, string>(this.MulliganRules));
            }
            else
            {
                this.MulliganRulesDB.Add(behavName, new Dictionary<string, string>(this.MulliganRules));
            }
        }

        private string getClearRule(string ruleKey)
        {
            if (this.MulliganRules.ContainsKey(ruleKey))
            {
                var clearRule = new StringBuilder("", 2000);
                var rKey = ruleKey.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                var rValue = this.MulliganRules[ruleKey].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                clearRule.Append(rKey[0]).Append(";").Append(rKey[1]).Append(";").Append(rKey[2]).Append(";");
                clearRule.Append(rValue[0]).Append(":").Append(rValue[1]).Append(";").Append(rValue[2]).Append("\r\n");
                return clearRule.ToString();
            }

            return "noKey";
        }


        private string getMullRuleKey(SimCard cardIDM = null, CardClass ownMHero = CardClass.INVALID, CardClass enemyMHero = CardClass.INVALID, int isExtraRule = 0)
        {
            var MullRuleKey = new StringBuilder("", 500);
            MullRuleKey.Append(cardIDM ?? SimCard.None).Append(";").Append(ownMHero).Append(";").Append(enemyMHero).Append(";").Append(isExtraRule);
            return MullRuleKey.ToString();
        }

        private string joinSomeTxt(string v1 = "", string v2 = "", string v3 = "", string v4 = "", string v5 = "", string v6 = "", string v7 = "")
        {
            var retValue = new StringBuilder("", 500);
            retValue.Append(v1).Append(v2).Append(v3).Append(v4).Append(v5).Append(v6).Append(v7);
            return retValue.ToString();
        }

        public bool getHoldList(MulliganData mulliganData, Behavior behave)
        {
            this.cards.Clear();
            this.readRules(behave.BehaviorName());
            if (!this.mulliganRulesLoaded)
            {
                return false;
            }

            if (!(mulliganData.Cards.Count == 3 || mulliganData.Cards.Count == 4))
            {
                Helpfunctions.Instance.ErrorLog(
                    $"[Mulligan] Mulligan is not used, since it got number of cards: {this.cards.Count}");
                return false;
            }

            Log.InfoFormat("[开局留牌] 应用这个 {0} 规则:", behave.BehaviorName());

            for (var i = 0; i < mulliganData.Cards.Count; i++)
            {
                this.cards.Add(new CardIDEntity(mulliganData.Cards[i].Entity.Id, i));
            }

            var ownHeroClass = mulliganData.UserClass.Convert();
            var enemyHeroClass = mulliganData.OpponentClass.Convert();

            var manaRule = 4;
            var MullRuleKey = this.getMullRuleKey(SimCard.None, ownHeroClass, enemyHeroClass, 1);
            if (this.MulliganRules.ContainsKey(MullRuleKey))
            {
                var temp = this.MulliganRules[MullRuleKey].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                manaRule = Convert.ToInt32(temp[2]);
            }
            else
            {
                MullRuleKey = this.getMullRuleKey(SimCard.None, ownHeroClass, CardClass.INVALID, 1);
                if (this.MulliganRules.ContainsKey(MullRuleKey))
                {
                    var temp = this.MulliganRules[MullRuleKey].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                    manaRule = Convert.ToInt32(temp[2]);
                }
            }

            var Coin = new CardIDEntity("GAME_005", -888);
            if (this.cards.Count == 4)
            {
                this.cards.Add(Coin); //we have a coin
            }

            foreach (var CardIDEntityC in this.cards)
            {
                var c = CardIDEntityC.id;
                if (CardIDEntityC.hold == 0 && CardIDEntityC.holdByRule == 0)
                {
                    if (c.Cost < manaRule)
                    {
                        CardIDEntityC.holdByManarule = 2;
                        CardIDEntityC.holdReason = this.joinSomeTxt("保留这些卡牌因为法力值消耗:", c.Cost.ToString(), " 小于预定值:", manaRule.ToString());
                    }
                    else
                    {
                        CardIDEntityC.holdByManarule = -2;
                        CardIDEntityC.holdReason = this.joinSomeTxt("弃掉这些卡牌因为法力值消耗:", c.Cost.ToString(), " 没有小于预定值:", manaRule.ToString());
                    }
                }

                var allowedQuantitySimple = 0;
                var allowedQuantityExtra = 0;
                var hasRuleClassSimple = false;

                var hasRule = false;
                var MullRuleKeySimple = this.getMullRuleKey(c, ownHeroClass, enemyHeroClass); //Simple key for Class enemy
                if (this.MulliganRules.ContainsKey(MullRuleKeySimple))
                {
                    hasRule = true;
                    hasRuleClassSimple = true;
                }
                else
                {
                    MullRuleKeySimple = this.getMullRuleKey(c, ownHeroClass); //Simple key for ALL enemy
                    if (this.MulliganRules.ContainsKey(MullRuleKeySimple))
                    {
                        hasRule = true;
                    }
                }

                if (hasRule)
                {
                    var val = this.MulliganRules[MullRuleKeySimple].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                    allowedQuantitySimple = (val[1] == "2" ? 2 : 1) * (val[0] == "Hold" ? 1 : -1);
                }

                hasRule = false;
                var MullRuleKeyExtra = this.getMullRuleKey(c, ownHeroClass, enemyHeroClass, 1); //Extra key for Class enemy
                if (this.MulliganRules.ContainsKey(MullRuleKeyExtra))
                {
                    hasRule = true;
                }
                else if (!hasRuleClassSimple)
                {
                    MullRuleKeyExtra = this.getMullRuleKey(c, ownHeroClass, CardClass.INVALID, 1); //Extra key for ALL enemy
                    if (this.MulliganRules.ContainsKey(MullRuleKeyExtra))
                    {
                        hasRule = true;
                    }
                }

                if (hasRule)
                {
                    var val = this.MulliganRules[MullRuleKeyExtra].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                    allowedQuantityExtra = (val[1] == "2" ? 2 : 1) * (val[0] == "Hold" ? 1 : -1);
                }

                //superimpose Class rules to All rules
                var useHold = false;
                var useDiscard = false;
                var useHoldRule = false;
                var useDiscardRule = false;

                if (allowedQuantitySimple != 0 && allowedQuantitySimple != allowedQuantityExtra)
                {
                    if (allowedQuantitySimple > 0)
                    {
                        useHold = true;
                    }
                    else
                    {
                        useDiscard = true;
                    }
                }

                if (allowedQuantityExtra != 0)
                {
                    if (allowedQuantityExtra < 0)
                    {
                        useDiscardRule = true;
                    }
                    else
                    {
                        useHoldRule = true;
                    }
                }

                //apply the rules
                var MullRuleValueExtra = new string[3];
                if (allowedQuantityExtra != 0)
                {
                    MullRuleValueExtra = this.MulliganRules[MullRuleKeyExtra].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                }

                if (useDiscardRule)
                {
                    if (MullRuleValueExtra[2] != "/")
                    {
                        var addedCards = MullRuleValueExtra[2].Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
                        this.MulliganRulesManual.Clear();
                        foreach (var s in addedCards)
                        {
                            this.MulliganRulesManual.Add(s, "");
                        }

                        foreach (var tmp in this.cards)
                        {
                            if (CardIDEntityC.entitiy == tmp.entitiy)
                            {
                                continue;
                            }

                            if (this.MulliganRulesManual.ContainsKey(tmp.id))
                            {
                                CardIDEntityC.holdByRule = -2;
                                CardIDEntityC.holdReason = this.joinSomeTxt("符合规则而弃掉: ", this.getClearRule(MullRuleKeyExtra));
                                break;
                            }
                        }
                    }
                }
                else if (useDiscard)
                {
                    CardIDEntityC.hold = -2;
                    CardIDEntityC.holdReason = this.joinSomeTxt("符合规则而弃掉: ", this.getClearRule(MullRuleKeySimple));
                }

                if (useHoldRule)
                {
                    if (CardIDEntityC.holdByRule == 0)
                    {
                        var addedCards = MullRuleValueExtra[2].Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
                        this.MulliganRulesManual.Clear();
                        foreach (var s in addedCards)
                        {
                            this.MulliganRulesManual.Add(s, "");
                        }

                        var foundFreeCard = false;
                        for (var i = 0; i < this.cards.Count; i++)
                        {
                            if (CardIDEntityC.entitiy == this.cards[i].entitiy)
                            {
                                continue;
                            }

                            if (this.MulliganRulesManual.ContainsKey(this.cards[i].id))
                            {
                                CardIDEntityC.holdByRule = 2;
                                CardIDEntityC.holdReason = this.joinSomeTxt("符合规则而保留: ", this.getClearRule(MullRuleKeyExtra));
                                if (this.cards[i].holdByRule < 0)
                                {
                                    for (var j = i; j < this.cards.Count; j++)
                                    {
                                        if (CardIDEntityC.entitiy == this.cards[j].entitiy)
                                        {
                                            continue;
                                        }

                                        if (this.MulliganRulesManual.ContainsKey(this.cards[j].id))
                                        {
                                            if (this.cards[j].holdByRule < 0)
                                            {
                                                continue;
                                            }

                                            foundFreeCard = true;
                                            this.cards[j].holdByRule = 2;
                                            this.cards[j].holdReason = this.joinSomeTxt("符合规则而保留: ", this.getClearRule(MullRuleKeyExtra));
                                            break;
                                        }
                                    }

                                    if (!foundFreeCard)
                                    {
                                        foundFreeCard = true;
                                        this.cards[i].holdByRule = 2;
                                        this.cards[i].holdReason = this.joinSomeTxt("符合规则而保留: ", this.getClearRule(MullRuleKeyExtra));
                                        break;
                                    }
                                }
                                else
                                {
                                    foundFreeCard = true;
                                    this.cards[i].holdByRule = 2;
                                    this.cards[i].holdReason = this.joinSomeTxt("符合规则而保留: ", this.getClearRule(MullRuleKeyExtra));
                                }

                                if (allowedQuantityExtra == 1)
                                {
                                    foreach (var tmp in this.cards)
                                    {
                                        if (tmp.entitiy == CardIDEntityC.entitiy)
                                        {
                                            continue;
                                        }

                                        if (tmp.id == CardIDEntityC.id)
                                        {
                                            tmp.holdByRule = -2;
                                            tmp.holdReason = this.joinSomeTxt("符合规则而弃掉: ", this.getClearRule(MullRuleKeyExtra));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (useHold && CardIDEntityC.holdByRule != -2)
                {
                    if (CardIDEntityC.hold == 0)
                    {
                        CardIDEntityC.hold = 2;
                        CardIDEntityC.holdReason = this.joinSomeTxt("符合规则而保留: ", this.getClearRule(MullRuleKeySimple));
                        if (allowedQuantitySimple == 1)
                        {
                            CardIDEntityC.hold = 1;
                            foreach (var tmp in this.cards)
                            {
                                if (tmp.entitiy == CardIDEntityC.entitiy)
                                {
                                    continue;
                                }

                                if (tmp.id == CardIDEntityC.id)
                                {
                                    tmp.hold = -2;
                                    tmp.holdReason = this.joinSomeTxt("discard Second card by rule: ", this.getClearRule(MullRuleKeySimple));
                                }
                            }
                        }
                    }
                }
            }

            if (this.cards.Count == 5)
            {
                this.cards.Remove(Coin);
            }

            foreach (var c in this.cards)
            {
                if (c.holdByRule == 0)
                {
                    if (c.hold == 0)
                    {
                        c.holdByRule = c.holdByManarule;
                    }
                    else
                    {
                        c.holdByRule = c.hold;
                    }
                }
            }

            for (var i = 0; i < mulliganData.Cards.Count; i++)
            {
                mulliganData.Mulligans[i] = this.cards[i].holdByRule > 0 ? false : true;
                Log.InfoFormat("[开局留牌] {0} {1}.", mulliganData.Cards[i].Entity.Name, this.cards[i].holdReason);
            }

            return true;
        }
    }
}