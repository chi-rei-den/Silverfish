using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_811",
  "name": [
    "新月视界",
    "Lunar Visions"
  ],
  "text": [
    "抽两张牌，抽到的随从牌法力值消耗减少（2）点。",
    "Draw 2 cards. Minions drawn cost (2) less."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 5,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40615
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_811 : SimCard //* Lunar Visions
	{
		// Draw 2 cards. Minions drawn costs (2) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
        }
    }
}