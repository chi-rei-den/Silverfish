using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using log4net;
using Newtonsoft.Json;
using Triton.Bot.Settings;
using Triton.Common;
using Triton.Game.Mapping;
using Logger = Triton.Common.LogUtilities.Logger;

using Triton.Bot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Data;
using HearthDb.Enums;

namespace HREngine.Bots
{
    /// <summary>Settings for the DefaultRoutine. </summary>
    public class DefaultRoutineSettings : JsonSettings
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private static DefaultRoutineSettings _instance;

        /// <summary>The current instance for this class. </summary>
        public static DefaultRoutineSettings Instance
        {
            get { return _instance ?? (_instance = new DefaultRoutineSettings()); }
        }

        /// <summary>The default ctor. Will use the settings path "DefaultRoutine".</summary>
        public DefaultRoutineSettings()
            : base(GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "DefaultRoutine")))
        {
        }

        private CardClass _arenaPreferredClass1;
        private CardClass _arenaPreferredClass2;
        private CardClass _arenaPreferredClass3;
        private CardClass _arenaPreferredClass4;
        private CardClass _arenaPreferredClass5;
        private string _defaultBehavior;

        /// <summary>
        /// The first hero choice for arena if present.
        /// </summary>
        [DefaultValue(CardClass.HUNTER)]
        public CardClass ArenaPreferredClass1
        {
            get { return _arenaPreferredClass1; }
            set
            {
                if (!value.Equals(_arenaPreferredClass1))
                {
                    _arenaPreferredClass1 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass1);

                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族1 = {0}.", _arenaPreferredClass1);
            }
        }

        /// <summary>
        /// The second hero choice for arena if present.
        /// </summary>
        [DefaultValue(CardClass.WARLOCK)]
        public CardClass ArenaPreferredClass2
        {
            get { return _arenaPreferredClass2; }
            set
            {
                if (!value.Equals(_arenaPreferredClass2))
                {
                    _arenaPreferredClass2 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass2);
                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族2 = {0}.", _arenaPreferredClass2);
            }
        }

        /// <summary>
        /// The third hero choice for arena if present.
        /// </summary>
        [DefaultValue(CardClass.PRIEST)]
        public CardClass ArenaPreferredClass3
        {
            get { return _arenaPreferredClass3; }
            set
            {
                if (!value.Equals(_arenaPreferredClass3))
                {
                    _arenaPreferredClass3 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass3);
                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族3 = {0}.", _arenaPreferredClass3);
            }
        }

        /// <summary>
        /// The fourth hero choice for arena if present.
        /// </summary>
        [DefaultValue(CardClass.ROGUE)]
        public CardClass ArenaPreferredClass4
        {
            get { return _arenaPreferredClass4; }
            set
            {
                if (!value.Equals(_arenaPreferredClass4))
                {
                    _arenaPreferredClass4 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass4);
                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族4 = {0}.", _arenaPreferredClass4);
            }
        }

        /// <summary>
        /// The fifth hero choice for arena if present.
        /// </summary>
        [DefaultValue(CardClass.WARRIOR)]
        public CardClass ArenaPreferredClass5
        {
            get { return _arenaPreferredClass5; }
            set
            {
                if (!value.Equals(_arenaPreferredClass5))
                {
                    _arenaPreferredClass5 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass5);
                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族5 = {0}.", _arenaPreferredClass5);
            }
        }

        private ObservableCollection<CardClass> _allClasses;

        /// <summary>All enum values for this type.</summary>
        [JsonIgnore]
        public ObservableCollection<CardClass> AllClasses
        {
            get
            {
                return _allClasses ?? (_allClasses = new ObservableCollection<CardClass>
                {
                    CardClass.DRUID,
                    CardClass.HUNTER,
                    CardClass.MAGE,
                    CardClass.PALADIN,
                    CardClass.PRIEST,
                    CardClass.ROGUE,
                    CardClass.SHAMAN,
                    CardClass.WARLOCK,
                    CardClass.WARRIOR,
                });
            }
        }

        // Behavior choice.
        [DefaultValue("Control")]
        public string DefaultBehavior
        {
            get { return _defaultBehavior; }
            set
            {
                if (!value.Equals(_defaultBehavior))
                {
                    _defaultBehavior = value;
                    NotifyPropertyChanged(() => DefaultBehavior);
                }
                Log.InfoFormat("[默认策略设置] 默认战斗模式 = {0}.", _defaultBehavior);
            }
        }

        private ObservableCollection<string> _allBehav;

        /// <summary>All enum values for this type.</summary>
        [JsonIgnore]
        public ObservableCollection<string> AllBehav
        {
            get
            {
                return _allBehav ?? (_allBehav = new ObservableCollection<string>(Silverfish.Instance.BehaviorDB.Keys));
            }
        }

	    private readonly List<int> _questIdsToCancel = new List<int>();

		[JsonIgnore]
	    public List<int> QuestIdsToCancel
	    {
		    get { return _questIdsToCancel; }
	    }
    }
}
