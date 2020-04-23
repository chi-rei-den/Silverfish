using HearthDb.Enums;
using log4net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Triton.Bot.Settings;
using Triton.Common;
using Logger = Triton.Common.LogUtilities.Logger;

namespace HREngine.Bots
{
    /// <summary>Settings for the DefaultRoutine. </summary>
    public class DefaultRoutineSettings : JsonSettings
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private static DefaultRoutineSettings _instance;

        /// <summary>The current instance for this class. </summary>
        public static DefaultRoutineSettings Instance => _instance ?? (_instance = new DefaultRoutineSettings());

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
            get => this._arenaPreferredClass1;
            set
            {
                if (!value.Equals(this._arenaPreferredClass1))
                {
                    this._arenaPreferredClass1 = value;
                    this.NotifyPropertyChanged(() => this.ArenaPreferredClass1);

                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族1 = {0}.", this._arenaPreferredClass1);
            }
        }

        /// <summary>
        /// The second hero choice for arena if present.
        /// </summary>
        [DefaultValue(CardClass.WARLOCK)]
        public CardClass ArenaPreferredClass2
        {
            get => this._arenaPreferredClass2;
            set
            {
                if (!value.Equals(this._arenaPreferredClass2))
                {
                    this._arenaPreferredClass2 = value;
                    this.NotifyPropertyChanged(() => this.ArenaPreferredClass2);
                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族2 = {0}.", this._arenaPreferredClass2);
            }
        }

        /// <summary>
        /// The third hero choice for arena if present.
        /// </summary>
        [DefaultValue(CardClass.PRIEST)]
        public CardClass ArenaPreferredClass3
        {
            get => this._arenaPreferredClass3;
            set
            {
                if (!value.Equals(this._arenaPreferredClass3))
                {
                    this._arenaPreferredClass3 = value;
                    this.NotifyPropertyChanged(() => this.ArenaPreferredClass3);
                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族3 = {0}.", this._arenaPreferredClass3);
            }
        }

        /// <summary>
        /// The fourth hero choice for arena if present.
        /// </summary>
        [DefaultValue(CardClass.ROGUE)]
        public CardClass ArenaPreferredClass4
        {
            get => this._arenaPreferredClass4;
            set
            {
                if (!value.Equals(this._arenaPreferredClass4))
                {
                    this._arenaPreferredClass4 = value;
                    this.NotifyPropertyChanged(() => this.ArenaPreferredClass4);
                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族4 = {0}.", this._arenaPreferredClass4);
            }
        }

        /// <summary>
        /// The fifth hero choice for arena if present.
        /// </summary>
        [DefaultValue(CardClass.WARRIOR)]
        public CardClass ArenaPreferredClass5
        {
            get => this._arenaPreferredClass5;
            set
            {
                if (!value.Equals(this._arenaPreferredClass5))
                {
                    this._arenaPreferredClass5 = value;
                    this.NotifyPropertyChanged(() => this.ArenaPreferredClass5);
                }
                Log.InfoFormat("[默认策略设置] 竞技场优先种族5 = {0}.", this._arenaPreferredClass5);
            }
        }

        private ObservableCollection<CardClass> _allClasses;

        /// <summary>All enum values for this type.</summary>
        [JsonIgnore]
        public ObservableCollection<CardClass> AllClasses
        {
            get
            {
                return this._allClasses ?? (this._allClasses = new ObservableCollection<CardClass>
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
            get => this._defaultBehavior;
            set
            {
                if (!value.Equals(this._defaultBehavior))
                {
                    this._defaultBehavior = value;
                    this.NotifyPropertyChanged(() => this.DefaultBehavior);
                }
                Log.InfoFormat("[默认策略设置] 默认战斗模式 = {0}.", this._defaultBehavior);
            }
        }

        private ObservableCollection<string> _allBehav;

        /// <summary>All enum values for this type.</summary>
        [JsonIgnore]
        public ObservableCollection<string> AllBehav => this._allBehav ?? (this._allBehav = new ObservableCollection<string>(Silverfish.Instance.BehaviorDB.Keys));

        private readonly List<int> _questIdsToCancel = new List<int>();

        [JsonIgnore]
        public List<int> QuestIdsToCancel => this._questIdsToCancel;
    }
}
