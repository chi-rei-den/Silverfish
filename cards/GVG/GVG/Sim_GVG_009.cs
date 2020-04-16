using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_009",
  "name": [
    "暗影投弹手",
    "Shadowbomber"
  ],
  "text": [
    "<b>战吼：</b>对每个英雄造成3点伤害。",
    "<b>Battlecry:</b> Deal 3 damage to each hero."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 1,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1937
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_009 : SimTemplate //Shadowbomber
    {

        //   Battlecry: Deal 3 damage to each hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = 3;
            p.minionGetDamageOrHeal(p.enemyHero, dmg, true);
            p.minionGetDamageOrHeal(p.ownHero, dmg, true);
        }


    }

}