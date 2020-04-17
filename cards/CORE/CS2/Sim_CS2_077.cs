using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_077",
  "name": [
    "疾跑",
    "Sprint"
  ],
  "text": [
    "抽四张牌。",
    "Draw 4 cards."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 7,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 630
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_077 : SimCard //sprint
	{

//    zieht 4 karten.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}

	}
}