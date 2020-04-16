using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_651",
  "name": [
    "纳迦海盗",
    "Naga Corsair"
  ],
  "text": [
    "<b>战吼：</b>使你的武器获得+1攻击力。",
    "<b>Battlecry:</b> Give your weapon +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40889
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_651 : SimTemplate //* Naga Corsair
	{
		// Battlecry: Give your weapon +1 Attack.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                if (p.ownWeapon.Durability > 0)
                {
                    p.ownWeapon.Angr++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
            }
            else
            {
                if (p.enemyWeapon.Durability > 0)
                {
                    p.enemyWeapon.Angr++;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
            }
        }
    }
}