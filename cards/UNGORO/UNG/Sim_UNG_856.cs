using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_856",
  "name": [
    "幻觉",
    "Hallucination"
  ],
  "text": [
    "<b>发现</b>一张你对手职业的卡牌。",
    "<b>Discover</b> a card from your opponent's class."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 42011
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_856 : SimCard //* Hallucination
	{
		//Discover a card from your opponent's class.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
            p.drawACard(CardDB.cardName.thecoin, ownplay, true);
			p.owncarddraw--;
        }
    }
}