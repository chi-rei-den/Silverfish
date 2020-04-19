using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_114",
  "name": [
    "巴内斯",
    "Barnes"
  ],
  "text": [
    "<b>战吼：</b>随机挑选你牌库里的一个随从，召唤一个1/1的复制。",
    "<b>Battlecry:</b> Summon a 1/1 copy of a random minion in your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39941
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_114 : SimTemplate //* Barnes
	{
		//Battlecry: Summon a 1/1 copy of a random minion in your deck.
		
        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.BilefinTidehunter_Ooze; //Ooze with Taunt
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.callKid(kid, own.zonepos, own.own);
		}
	}
}