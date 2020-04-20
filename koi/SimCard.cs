using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;
using HREngine.Bots;
using System;
using System.Reflection;

namespace Chireiden.Silverfish
{
    public partial class SimCard
    {
        public Card CardDef { get; private set; }

        public string CardId => this.CardDef.Id;

        public int DbfId => this.CardDef.DbfId;

        public int Attack => this.CardDef.Entity.GetTag(GameTag.ATK);

        public bool Battlecry => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.BATTLECRY));

        public bool Charge => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.CHARGE));

        public bool Combo => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.COMBO));

        public int Cost => this.CardDef.Entity.GetTag(GameTag.COST);

        public bool Deathrattle => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.DEATHRATTLE));

        public int Durability => this.CardDef.Entity.GetTag(GameTag.DURABILITY);

        public bool DivineShield => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.DIVINE_SHIELD));

        public bool Echo => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.ECHO));

        public bool Enrage => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.ENRAGED));

        public bool Freeze => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.FREEZE));

        public int Health => this.CardDef.Entity.GetTag(GameTag.HEALTH);

        public bool Immune => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.IMMUNE));

        public bool Lifesteal => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.LIFESTEAL));

        public bool Overkill => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.OVERKILL));

        public int Overload => this.CardDef.Entity.GetTag(GameTag.OVERLOAD);

        public bool Poisonous => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.POISONOUS));

        public bool Quest => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.QUEST));

        public Race Race => (Race)this.CardDef.Entity.GetTag(GameTag.CARDRACE);

        public Rarity Rarity => (Rarity)this.CardDef.Entity.GetTag(GameTag.RARITY);

        public bool Reborn => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.REBORN));

        public bool Rush => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.RUSH));

        public bool Secret => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.SECRET));

        public bool Sidequest => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.SIDEQUEST));

        public int Spellpower => this.CardDef.Entity.GetTag(GameTag.SPELLPOWER);

        public bool Stealth => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.STEALTH));

        public bool Taunt => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.TAUNT));

        public bool Twinspell => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.TWINSPELL));

        public CardType Type => (CardType)this.CardDef.Entity.GetTag(GameTag.CARDTYPE);

        public bool Windfury => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.WINDFURY));

        public string LocName => this.CardDef.GetLocName(Locale);

        public SimTemplate Simulator => (SimTemplate)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType($"Sim_{this.CardId}"));

        public override int GetHashCode()
        {
            return this.CardDef.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.CardDef.Equals(obj);
        }

        static SimCard()
        {
#if ENUS
            Locale = Locale.enUS;
#else
            Locale = Locale.zhCN;
#endif
        }

        public static Locale Locale { get; private set; }

        public static bool operator ==(SimCard a, SimCard b) => a.CardDef.DbfId == b.CardDef.DbfId;

        public static bool operator !=(SimCard a, SimCard b) => !(a == b);

        public static implicit operator SimCard(string name) => FromName(name);

        public static SimCard FromName(string name)
        {
            if (!Cards.Collectible.TryGetValue(name, out var card) && !Cards.All.TryGetValue(name, out card))
            {
                card = Cards.GetFromName(name, Locale.enUS)
                ?? Cards.GetFromName(name, Locale.zhCN)
                ?? Cards.GetFromName(name, Locale.enUS, false)
                ?? Cards.GetFromName(name, Locale.zhCN, false);
            }
            return card != null ? new SimCard { CardDef = card } : null;
        }

        public const string None = CardIds.NonCollectible.Neutral.GoldenLegendary; // A do-nothing card
        public static SimCard NoneCard => None; // A do-nothing card
    }
}