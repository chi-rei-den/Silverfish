﻿using System.Collections.Generic;
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

        private TAG_CLASS _arenaPreferredClass1;
        private TAG_CLASS _arenaPreferredClass2;
        private TAG_CLASS _arenaPreferredClass3;
        private TAG_CLASS _arenaPreferredClass4;
        private TAG_CLASS _arenaPreferredClass5;
        private string _defaultBehavior;

        /// <summary>
        /// The first hero choice for arena if present.
        /// </summary>
        [DefaultValue(TAG_CLASS.HUNTER)]
        public TAG_CLASS ArenaPreferredClass1
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
        [DefaultValue(TAG_CLASS.WARLOCK)]
        public TAG_CLASS ArenaPreferredClass2
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
        [DefaultValue(TAG_CLASS.PRIEST)]
        public TAG_CLASS ArenaPreferredClass3
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
        [DefaultValue(TAG_CLASS.ROGUE)]
        public TAG_CLASS ArenaPreferredClass4
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
        [DefaultValue(TAG_CLASS.WARRIOR)]
        public TAG_CLASS ArenaPreferredClass5
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

        private ObservableCollection<TAG_CLASS> _allClasses;

        /// <summary>All enum values for this type.</summary>
        [JsonIgnore]
        public ObservableCollection<TAG_CLASS> AllClasses
        {
            get
            {
                return _allClasses ?? (_allClasses = new ObservableCollection<TAG_CLASS>
                {
                    TAG_CLASS.DRUID,
                    TAG_CLASS.HUNTER,
                    TAG_CLASS.MAGE,
                    TAG_CLASS.PALADIN,
                    TAG_CLASS.PRIEST,
                    TAG_CLASS.ROGUE,
                    TAG_CLASS.SHAMAN,
                    TAG_CLASS.WARLOCK,
                    TAG_CLASS.WARRIOR,
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
