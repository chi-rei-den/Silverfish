using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_057",
  "name": [
    "兽栏大师",
    "Stablemaster"
  ],
  "text": [
    "<b>战吼：</b>在本回合中，使一个友方野兽获得<b>免疫</b>。",
    "<b>Battlecry:</b> Give a friendly Beast <b>Immune</b> this turn."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2639
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_057 : SimTemplate //* Stablemaster
	{
		//Battlecry: Give a friendly Beast Immune this Turn.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) target.immune = true;
		}
	}
}