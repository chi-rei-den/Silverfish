using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_593",
  "name": [
    "夜刃刺客",
    "Nightblade"
  ],
  "text": [
    "<b>战吼：</b>对敌方英雄造成3点伤害。",
    "<b>Battlecry: </b>Deal 3 damage to the enemy hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 670
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_593 : SimCard //nightblade
    {

        //    kampfschrei: /fügt dem feindlichen helden 3 schaden zu.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(own.own ? p.enemyHero : p.ownHero, 3);
        }

    }
}