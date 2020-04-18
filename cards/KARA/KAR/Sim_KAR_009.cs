using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_009",
  "name": [
    "呓语魔典",
    "Babbling Book"
  ],
  "text": [
    "<b>战吼：</b>随机将一张法师法术牌置入你的\n手牌。",
    "<b>Battlecry:</b> Add a random Mage spell to your hand."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39169
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_009 : SimTemplate //* Babbling Book
	{
		//Battlecry: Add a random Mage spell to your hand.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.frostbolt, own.own, true);
		}
	}
}