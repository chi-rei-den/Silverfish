using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "DS1_233",
  "name": [
    "心灵震爆",
    "Mind Blast"
  ],
  "text": [
    "对敌方英雄造成$5点伤害。",
    "Deal $5 damage to the enemy hero."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "HOF",
  "collectible": true,
  "dbfId": 545
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DS1_233 : SimCard //mindblast
    {

        //    fügt dem feindlichen helden $5 schaden zu.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);

            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
        }

    }
}