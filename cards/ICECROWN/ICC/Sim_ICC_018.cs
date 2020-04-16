using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_018",
  "name": [
    "幻影海盗",
    "Phantom Freebooter"
  ],
  "text": [
    "<b>战吼：</b>\n获得等同于你的武器属性的属性值。",
    "<b>Battlecry:</b> Gain stats equal to your weapon's."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42327
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_018: SimTemplate //* Phantom Freebooter
    {
        // Battlecry: Gain stats equal to your weapon's.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetBuffed(own, 1, 1);
            if (own.own)
            {
                own.Angr += p.ownWeapon.Angr;
                own.Hp += p.ownWeapon.Durability;
                own.maxHp += p.ownWeapon.Durability;
            }
            else
            {
                own.Angr += p.enemyWeapon.Angr;
                own.Hp += p.enemyWeapon.Durability;
                own.maxHp += p.enemyWeapon.Durability;
            }
        }
    }
}
