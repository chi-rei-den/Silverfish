using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_061",
  "name": [
    "子弹上膛",
    "Lock and Load"
  ],
  "text": [
    "在本回合中，每当你施放一个法术，随机将一张猎人卡牌置入你的手牌。",
    "Each time you cast a spell this turn, add a random Hunter card to your hand."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2484
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_061 : SimCard //* Lock and Load
	{
		//Each time you cast a spell this turn, add a random Hunter card to your hand.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{			
            if (ownplay)
            {
                p.lockandload++;
            }
		}
	}
}