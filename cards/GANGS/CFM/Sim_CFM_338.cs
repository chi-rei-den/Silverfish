using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_338",
  "name": [
    "穴居人驯兽师",
    "Trogg Beastrager"
  ],
  "text": [
    "<b>战吼：</b>随机使你手牌中的一张野兽牌获得+1/+1。",
    "<b>Battlecry:</b> Give a random Beast in your hand +1/+1."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40684
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_338 : SimTemplate //* Trogg Beastrager
	{
        // Battlecry: Give a random Beast in your hand +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                Handcard hc = p.searchRandomMinionInHand(p.owncards, SearchMode.ByCost, SearchMode.BeastOnly);
                if (hc != null)
                {
                    hc.addattack++;
                    hc.addHp++;
                    p.anzOwnExtraAngrHp += 2;
                }
            }
        }
	}
}