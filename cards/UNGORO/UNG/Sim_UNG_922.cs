using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_922",
  "name": [
    "探索安戈洛",
    "Explore Un'Goro"
  ],
  "text": [
    "将你牌库里的所有卡牌替换成\n“<b>发现</b>一张牌”。",
    "Replace your deck with copies of \"<b>Discover</b> a card.\""
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41400
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_922 : SimCard //* Explore Un'Goro
	{
		//Replace your deck with copies of "Discover a card."

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.evaluatePenality -= 20;
        }
    }
}