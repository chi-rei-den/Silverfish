using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_853",
  "name": [
    "污手街走私者",
    "Grimestreet Smuggler"
  ],
  "text": [
    "<b>战吼：</b>随机使你手牌中的一张随从牌获得+1/+1。",
    "<b>Battlecry:</b> Give a random minion in your hand +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40743
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_853 : SimTemplate //* Grimestreet Smuggler
	{
        // Battlecry: Give a random minion in your hand +1/+1

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.Mob);
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