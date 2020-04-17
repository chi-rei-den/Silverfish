using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_942t",
  "name": [
    "老鲨嘴",
    "Megafin"
  ],
  "text": [
    "<b>战吼：</b>\n随机将鱼人牌置入你的手牌，直到你的手牌数量达到上限。",
    "<b>Battlecry:</b> Fill your hand with random Murlocs."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 5,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41498
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_942t : SimCard //* Megafin
	{
		//Battlecry: Fill your hand with random Murlocs.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				p.owncarddraw += 10 - p.owncards.Count;
			}
		}
	}
}