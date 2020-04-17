using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_066",
  "name": [
    "酸性沼泽软泥怪",
    "Acidic Swamp Ooze"
  ],
  "text": [
    "<b>战吼：</b>\n摧毁对手的武器。",
    "<b>Battlecry:</b> Destroy your opponent's weapon."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 906
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_066 : SimCard //acidicswampooze
	{

//    kampfschrei:/ zerstört die waffe eures gegners.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.lowerWeaponDurability(1000, !own.own);
		}


	}
}