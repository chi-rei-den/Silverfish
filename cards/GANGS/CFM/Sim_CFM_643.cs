using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_643",
  "name": [
    "霍巴特·钩锤",
    "Hobart Grapplehammer"
  ],
  "text": [
    "<b>战吼：</b>使你的手牌和牌库里的所有武器牌获得+1攻击力。",
    "<b>Battlecry:</b> Give all weapons in your hand and deck +1 Attack."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 2,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40482
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_643 : SimCard //* Hobart Grapplehammer
	{
		// Battlecry: Give all weapons in your hand and deck +1 Attack.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.WEAPON) hc.addattack++;
                }
            }
        }
    }
}