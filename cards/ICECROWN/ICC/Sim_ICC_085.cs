using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_085",
  "name": [
    "终极感染",
    "Ultimate Infestation"
  ],
  "text": [
    "造成$5点伤害。抽五张牌。获得5点护甲值。召唤一个5/5的食尸鬼。",
    "[x]Deal $5 damage. Draw\n5 cards. Gain 5 Armor.\nSummon a 5/5 Ghoul."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 10,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42759
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_085: SimTemplate //* Ultimate Infestation
    {
        // Deal 5 damage. Draw 5 cards. Gain 5 Armor. Summon a 5/5 Ghoul.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Druid.UltimateInfestation_GhoulInfestorToken; //Ghoul Infestor

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);

            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);

            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 5);

            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay);
        }
    }
}