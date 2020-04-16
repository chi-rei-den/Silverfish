using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_057",
  "name": [
    "年迈的酒仙",
    "Ancient Brewmaster"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从从战场上移回你的手牌。",
    "<b>Battlecry:</b> Return a friendly minion from the battlefield to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 186
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_057 : SimTemplate //ancientbrewmaster
	{

//    kampfschrei:/ lasst einen befreundeten diener vom schlachtfeld auf eure hand zurückkehren.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionReturnToHand(target, target.own, 0);
		}

	}
}