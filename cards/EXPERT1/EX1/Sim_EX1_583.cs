using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_583",
  "name": [
    "艾露恩的女祭司",
    "Priestess of Elune"
  ],
  "text": [
    "<b>战吼：</b>为你的英雄恢复#4点生命值。",
    "<b>Battlecry:</b> Restore #4 Health to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 424
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_583 : SimTemplate //priestessofelune
    {

        //    kampfschrei:/ stellt bei eurem helden 4 leben wieder her.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(4) : p.getEnemyMinionHeal(4);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal);
        }


    }
}