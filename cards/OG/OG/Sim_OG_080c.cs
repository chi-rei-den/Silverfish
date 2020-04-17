using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_080c",
  "name": [
    "血蓟毒素",
    "Bloodthistle Toxin"
  ],
  "text": [
    "将一个友方随从移回你的手牌。\n它的法力值消耗减少（2）点。",
    "Return a friendly minion to your hand.\nIt costs (2) less."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "OG",
  "collectible": null,
  "dbfId": 38938
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_080c : SimCard //* Bloodthistle Toxin
	{
        //Return a friendly minion to your hand. It costs (2) less.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToHand(target, ownplay, -2);
		}
	}
}