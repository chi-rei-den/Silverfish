using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_907",
  "name": [
    "欧泽鲁克",
    "Ozruk"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>在上个回合，你每使用一张元素牌，便获得+5生命值。",
    "[x]<b>Taunt</b>\n<b>Battlecry:</b> Gain +5 Health\nfor each Elemental you\nplayed last turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41294
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_907 : SimCard //* Ozruk
	{
		//Taunt. Battlecry: Gain +5 Health for each Elemental you played last turn.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.minionGetBuffed(own, p.anzOwnElementalsLastTurn * 5, p.anzOwnElementalsLastTurn * 5);
		}
	}
}