using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_031",
  "name": [
    "回收",
    "Recycle"
  ],
  "text": [
    "将一个敌方随从洗入你对手的\n牌库。",
    "Shuffle an enemy minion into your opponent's deck."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1995
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_031 : SimTemplate //* Recycle
    {
        //   Shuffle an enemy minion into your opponent's deck.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToDeck(target, !ownplay);
		}
	}
}