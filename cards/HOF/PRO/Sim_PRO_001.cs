using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "PRO_001",
  "name": [
    "精英牛头人酋长",
    "Elite Tauren Chieftain"
  ],
  "text": [
    "<b>战吼：</b>让两位玩家都具有摇滚的能力！（双方各获得一张强力和弦牌）",
    "<b>Battlecry:</b> Give both players the power to ROCK! (with a Power Chord card)"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "HOF",
  "collectible": true,
  "dbfId": 1754
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_PRO_001 : SimTemplate //elitetaurenchieftain
	{

//    kampfschrei:/ verleiht beiden spielern die macht des rock! (durch eine powerakkordkarte)
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.roguesdoit, true, true);
            p.drawACard(CardDB.cardName.roguesdoit, false, true);
		}

	}
}