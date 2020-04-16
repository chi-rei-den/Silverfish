using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_752",
  "name": [
    "失窃物资",
    "Stolen Goods"
  ],
  "text": [
    "随机使你手牌中的一张具有<b>嘲讽</b>的随从牌获得+3/+3。",
    "Give a random <b>Taunt</b> minion in your hand +3/+3."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40566
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_752 : SimTemplate //* Stolen Goods
	{
        // Give a random Taunt minion in your hand +3/+3.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.TAUNT);
                if (hc != null)
                {
                    hc.addattack += 3;
                    hc.addHp += 3;
                    p.anzOwnExtraAngrHp += 6;
                }
            }
        }
	}
}