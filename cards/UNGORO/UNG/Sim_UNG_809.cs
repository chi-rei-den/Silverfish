using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_809",
  "name": [
    "火羽精灵",
    "Fire Fly"
  ],
  "text": [
    "<b>战吼：</b>将一张1/2的元素牌置入你的手牌。",
    "<b>Battlecry</b>: Add a 1/2 Elemental to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41323
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_809 : SimCard //* Fire Fly
	{
		//Battlecry: Add a 1/2 Elemental to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.UNG_809t1, own.own, true);
        }
	}
}