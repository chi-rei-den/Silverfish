using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_042",
  "name": [
    "火元素",
    "Fire Elemental"
  ],
  "text": [
    "<b>战吼：</b>造成3点伤害。",
    "<b>Battlecry:</b> Deal 3 damage."
  ],
  "CardClass": "SHAMAN",
  "type": "MINION",
  "cost": 6,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 189
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_042 : SimTemplate //fireelemental
	{

//    kampfschrei:/ verursacht 3 schaden.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 3;
            p.minionGetDamageOrHeal(target, dmg);
           
		}

	}
}