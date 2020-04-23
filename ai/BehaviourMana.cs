using System;
using Chireiden.Silverfish;

namespace HREngine.Bots
{
    public class BehaviorMana : Behavior
    {
        PenalityManager penman = PenalityManager.Instance;

        public override string BehaviorName() { return "Mana"; }

        public override float getPlayfieldValue(Playfield p)
        {
            if (p.value >= -2000000)
            {
                return p.value;
            }

            var retval = 0;

            retval += p.ownHero.Hp + p.ownHero.armor;
            retval -= p.enemyHero.Hp + p.enemyHero.armor;

            foreach (var m in p.ownMinions)
            {
                retval += this.getEnemyMinionValue(m, p);
            }

            foreach (var m in p.enemyMinions)
            {
                retval -= this.getEnemyMinionValue(m, p);
            }

            foreach (var hc in p.owncards)
            {
                var r = Math.Max(hc.getManaCost(p), 1);
                if (hc.card == SimCard.None)
                {
                    r = 4;
                }

                retval += r;
            }

            retval -= p.enemySecretCount;
            retval -= p.lostDamage; //damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            retval -= p.lostWeaponDamage;
            if (p.enemyHero.Hp <= 0)
            {
                retval = 10000;
            }

            if (p.enemyHero.Hp >= 1 && p.guessingHeroHP <= 0)
            {
                retval += p.owncarddraw * 500;
                retval -= 1000;
            }

            if (p.ownHero.Hp <= 0)
            {
                retval -= 10000;
            }

            p.value = retval;
            return retval;
        }

        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            var retval = 0;
            retval += m.handcard.card.Cost;
            if (m.handcard.card == SimCard.None)
            {
                retval = 4;
            }

            return retval;
        }
    }
}