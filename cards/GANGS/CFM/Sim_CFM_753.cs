using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_753",
  "name": [
    "污手街供货商",
    "Grimestreet Outfitter"
  ],
  "text": [
    "<b>战吼：</b>使你手牌中的所有随从牌获得+1/+1。",
    "<b>Battlecry:</b> Give all minions in your hand +1/+1."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40567
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_753 : SimTemplate //* Grimestreet Outfitter
	{
		// Battlecry: Give all minions in your hand +1/+1.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                foreach (Handcard hc in p.owncards)
                {
                    if (hc.card.Type == CardType.MINION)
                    {
                        hc.addattack++;
                        hc.addHp++;
                        p.anzOwnExtraAngrHp += 2;
                    }
                }
            }
        }
	}
}