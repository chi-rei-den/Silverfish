using System;
using System.Linq;
using HearthDb.Enums;
using HREngine.Bots;

namespace Chireiden.Silverfish
{
    public static class SearchMode
    {
        public static Func<T, int> Combine<T>(params Func<T, int>[] delegates)
        {
            return value => delegates.Aggregate(default(int), (prev, func) =>
                prev == int.MinValue || func(value) == int.MinValue ? int.MinValue : prev + func(value));
        }

        public static int LowAttack(Minion minion) { return minion.Angr; }
        public static int LowAttack(Handcard card) { return card.card.Attack; }
        public static int HighAttack(Minion minion) { return -minion.Angr; }
        public static int HighAttack(Handcard card) { return -card.card.Attack; }

        public static int LowHealth(Minion minion) { return minion.Hp; }
        public static int LowHealth(Handcard card) { return card.card.Health; }
        public static int HighHealth(Minion minion) { return -minion.Hp; }
        public static int HighHealth(Handcard card) { return -card.card.Health; }

        public static int LowMaxHealth(Minion minion) { return minion.maxHp; }
        public static int LowMaxHealth(Handcard card) { return card.card.Health; }
        public static int HighMaxHealth(Minion minion) { return -minion.maxHp; }
        public static int HighMaxHealth(Handcard card) { return -card.card.Health; }

        public static int LowCost(Minion minion) { return minion.name.Cost; }
        public static int LowCost(Handcard card) { return card.card.Cost; }
        public static int HighCost(Minion minion) { return -minion.name.Cost; }
        public static int HighCost(Handcard card) { return -card.card.Cost; }

        public static int LifestealOnly(Minion minion) { return minion.name.Lifesteal ? 0 : int.MinValue; }
        public static int LifestealOnly(Handcard card) { return card.card.Lifesteal ? 0 : int.MinValue; }

        public static int TauntOnly(Minion minion) { return minion.name.Taunt ? 0 : int.MinValue; }
        public static int TauntOnly(Handcard card) { return card.card.Taunt ? 0 : int.MinValue; }

        public static int WeaponOnly(Minion minion) { return minion.name.Type == CardType.WEAPON ? 0 : int.MinValue; }
        public static int WeaponOnly(Handcard card) { return card.card.Type == CardType.WEAPON ? 0 : int.MinValue; }

        public static int MinionOnly(Minion minion) { return minion.name.Type == CardType.MINION ? 0 : int.MinValue; }
        public static int MinionOnly(Handcard card) { return card.card.Type == CardType.MINION ? 0 : int.MinValue; }

        public static int BeastOnly(Minion minion) { return minion.name.Race == Race.BEAST ? 0 : int.MinValue; }
        public static int BeastOnly(Handcard card) { return card.card.Race == Race.BEAST ? 0 : int.MinValue; }

        public static int MurlocOnly(Minion minion) { return minion.name.Race == Race.MURLOC ? 0 : int.MinValue; }
        public static int MurlocOnly(Handcard card) { return card.card.Race == Race.MURLOC ? 0 : int.MinValue; }
    }
}