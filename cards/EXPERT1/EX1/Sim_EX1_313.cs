using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_313",
  "name": [
    "深渊领主",
    "Pit Lord"
  ],
  "text": [
    "<b>战吼：</b>对你的英雄造成5点伤害。",
    "<b>Battlecry:</b> Deal 5 damage to your hero."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 783
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_313 : SimTemplate //pitlord
    {

        //    kampfschrei:/ fügt eurem helden 5 schaden zu.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, 5);
        }


    }
}