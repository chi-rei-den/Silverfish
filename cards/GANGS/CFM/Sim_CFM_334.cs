using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_334",
  "name": [
    "走私货物",
    "Smuggler's Crate"
  ],
  "text": [
    "随机使你手牌中的一张野兽牌获得+2/+2。",
    "Give a random Beast in your hand +2/+2."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40679
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_334 : SimTemplate //* Smuggler's Crate
	{
		// Give a random Beast in your hand +2/+2.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                Handcard hc = p.searchRandomMinionInHand(p.owncards, SearchMode.LowCost, GameTag.CARDRACE, Race.PET);
                if (hc != null)
                {
                    hc.addattack += 2;
                    hc.addHp += 2;
                    p.anzOwnExtraAngrHp += 4;
                }
            }
        }
    }
}
