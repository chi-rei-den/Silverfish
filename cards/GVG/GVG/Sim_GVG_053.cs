using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_053",
  "name": [
    "盾甲侍女",
    "Shieldmaiden"
  ],
  "text": [
    "<b>战吼：</b>\n获得5点护甲值。",
    "<b>Battlecry:</b> Gain 5 Armor."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2021
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_053 : SimTemplate //Shieldmaiden
    {

        //   Battlecry:&lt;/b&gt; Gain 5 Armor.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.minionGetArmor(p.ownHero, 5);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 5);
            }
        }

    }

}