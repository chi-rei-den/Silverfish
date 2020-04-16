using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_267",
  "name": [
    "南海畸变船长",
    "Southsea Squidface"
  ],
  "text": [
    "<b>亡语：</b>使你的武器获得+2攻击力。",
    "<b>Deathrattle:</b> Give your weapon +2 Attack."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38825
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_267 : SimTemplate //* Southsea Squidface
	{
		//Deathrattle: Give your weapon +2 Attack.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Angr += 2;
                    p.ownHero.Angr += 2;
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr += 2;
                    p.enemyHero.Angr += 2;
                }
            }
        }
	}
}