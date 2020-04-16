using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_650",
  "name": [
    "暗鳞劫掠者",
    "Grimscale Chum"
  ],
  "text": [
    "<b>战吼：</b>随机使你手牌中的一张鱼人牌获得+1/+1。",
    "[x]<b>Battlecry:</b> Give a random\nMurloc in your hand +1/+1."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40531
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_650 : SimTemplate //* Grimscale Chum
	{
		// Battlecry: Give a random Murloc in your hand +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.MURLOC);
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