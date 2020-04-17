using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_066",
  "name": [
    "奥格瑞玛狼骑士",
    "Orgrimmar Aspirant"
  ],
  "text": [
    "<b>激励：</b>使你的武器获得+1攻击力。",
    "<b>Inspire:</b> Give your weapon +1 Attack."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2711
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_066 : SimCard //* Orgrimmar Aspirant
	{
		//Inspire: Give your weapon +1 Attack.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
                if (own)
                {
                    if (p.ownWeapon.Durability > 0) p.ownWeapon.Angr++;
                }
                else
                {
                    if (p.enemyWeapon.Durability > 0) p.enemyWeapon.Angr++;
                }
			}
        }
	}
}