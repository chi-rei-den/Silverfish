using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_092",
  "name": [
    "虚灵大盗拉法姆",
    "Arch-Thief Rafaam"
  ],
  "text": [
    "<b>战吼：发现</b>一张强大的神器牌。",
    "<b>Battlecry: Discover</b> a powerful Artifact."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2964
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_092 : SimTemplate //* Arch-Thief Rafaam
	{
		//Battlecry: Discover a powerful Artifact.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.lanternofpower, own.own, true);
		}
	}
}