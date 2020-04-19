using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_075",
  "name": [
    "影袭",
    "Sinister Strike"
  ],
  "text": [
    "对敌方英雄造成$3点伤害。",
    "Deal $3 damage to the enemy hero."
  ],
  "CardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 710
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_075 : SimTemplate //sinisterstrike
    {

        //    fügt dem feindlichen helden $3 schaden zu.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);

        }

    }
}