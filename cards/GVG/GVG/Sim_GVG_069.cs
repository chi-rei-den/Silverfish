using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_069",
  "name": [
    "老式治疗机器人",
    "Antique Healbot"
  ],
  "text": [
    "<b>战吼：</b>为你的英雄恢复#8点生命值。",
    "<b>Battlecry:</b> Restore #8 Health to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2037
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_069 : SimTemplate //Antique Healbot
    {

        //   Battlecry: Restore 8 Health to your hero.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                int heal = p.getMinionHeal(8);
                p.minionGetDamageOrHeal(p.ownHero, -heal, true);
            }
            else
            {
                int heal = p.getEnemyMinionHeal(8);
                p.minionGetDamageOrHeal(p.enemyHero, -heal, true);
            }
        }

    }

}