using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_025",
  "name": [
    "血帆海盗",
    "Bloodsail Corsair"
  ],
  "text": [
    "<b>战吼：</b>使对手的武器失去1点耐久度。",
    "[x]<b>Battlecry:</b> Remove\n1 Durability from your\nopponent's weapon."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 997
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NEW1_025 : SimCard //bloodsailcorsair
	{

//    kampfschrei:/ zieht 1 haltbarkeit von der waffe eures gegners ab.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.lowerWeaponDurability(1, !own.own);
		}


	}
}