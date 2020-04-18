using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_007",
  "name": [
    "嗜法者",
    "Spellslinger"
  ],
  "text": [
    "<b>战吼：</b>随机将一张法术牌置入每个玩家的手牌。",
    "<b>Battlecry:</b> Add a random spell to each player's hand."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2571
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_007 : SimTemplate //* Spellslinger
	{
		//Battlecry: Add a random spell card to each player's hand.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardIds.Collectible.Mage.Frostbolt, true, true);
            p.drawACard(CardIds.Collectible.Mage.Frostbolt, false, true);
		}
	}
}