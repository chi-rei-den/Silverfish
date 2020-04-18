using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_619",
  "name": [
    "暗金教炼金师",
    "Kabal Chemist"
  ],
  "text": [
    "<b>战吼：</b>随机将一张药水牌置入你的手牌。",
    "<b>Battlecry:</b> Add a random Potion to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40407
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_619 : SimTemplate //* Kabal Chemist
	{
		// Battlecry: Add a random Potion to your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.frostbolt, m.own, true);
        }
    }
}