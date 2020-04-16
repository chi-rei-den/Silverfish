using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_051",
  "name": [
    "禁忌古树",
    "Forbidden Ancient"
  ],
  "text": [
    "<b>战吼：</b>消耗你所有的法力值，每消耗一点法力值，便获得+1/+1。",
    "<b>Battlecry:</b> Spend all your Mana. Gain +1/+1 for each Mana spent."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 1,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38340
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_051 : SimTemplate //* Forbidden Ancient
	{
		//Battlecry: Spend all your Mana. Gain +1/+1 for each mana spent.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				p.minionGetBuffed(own, p.mana, p.mana);
				p.mana = 0;
			}
		}
	}
}