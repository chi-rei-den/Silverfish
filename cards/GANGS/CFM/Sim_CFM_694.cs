using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_694",
  "name": [
    "暗影大师",
    "Shadow Sensei"
  ],
  "text": [
    "<b>战吼：</b>使一个<b>潜行</b>的随从获得+2/+2。",
    "<b>Battlecry:</b> Give a <b>Stealthed</b> minion +2/+2."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40695
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_694 : SimCard //* Shadow Sensei
	{
		// Battlecry: Give a Stealth minion +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 2, 2);
        }
    }
}