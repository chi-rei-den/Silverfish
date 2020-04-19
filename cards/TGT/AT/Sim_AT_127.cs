using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_127",
  "name": [
    "虚灵勇士萨兰德",
    "Nexus-Champion Saraad"
  ],
  "text": [
    "<b>激励：</b>随机将一张法术牌置入你的手牌。",
    "<b>Inspire:</b> Add a random spell to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2683
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_127 : SimTemplate //* Nexus-Champion Saraad
	{
		//Inspire: Add a random spell to your hand.
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
                p.drawACard(CardIds.Collectible.Mage.Frostbolt, own, true);
			}
        }
	}
}