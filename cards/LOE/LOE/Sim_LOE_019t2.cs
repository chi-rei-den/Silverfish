using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_019t2",
  "name": [
    "黄金猿",
    "Golden Monkey"
  ],
  "text": [
    "<b>嘲讽</b>\n<b>战吼：</b>将你的手牌和牌库里的卡牌替换成<b>传说</b>随从。",
    "<b>Taunt</b>\n<b>Battlecry:</b> Replace your hand and deck with <b>Legendary</b> minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": null,
  "set": "LOE",
  "collectible": null,
  "dbfId": 2993
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_019t2 : SimCard //* Golden Monkey
	{
		//Taunt. Battlecry: Replace your hand and deck with Legendary minions.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			int bonus = 0;
            if (own.own) bonus = -5 * p.owncards.Count;
            else bonus = 5 * p.enemyAnzCards;
			p.evaluatePenality += bonus;
		}
	}
}