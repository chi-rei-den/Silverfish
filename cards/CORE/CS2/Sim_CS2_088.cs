using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_088",
  "name": [
    "列王守卫",
    "Guardian of Kings"
  ],
  "text": [
    "<b>战吼：</b>为你的英雄恢复#6点生命值。",
    "<b>Battlecry:</b> Restore #6 Health to your hero."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 7,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1068
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_088 : SimCard //guardianofkings
    {

        //    kampfschrei:/ stellt bei eurem helden 6 leben wieder her.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);

            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal);
        }


    }
}