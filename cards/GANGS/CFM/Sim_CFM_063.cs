using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_063",
  "name": [
    "化学怪人",
    "Kooky Chemist"
  ],
  "text": [
    "<b>战吼：</b>\n使一个随从的攻击力和生命值互换。",
    "<b>Battlecry:</b> Swap the Attack and Health of a minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40289
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_063 : SimCard //* Kooky Chemist
	{
		// Battlecry: Swap the Attack and Health of a minion.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionSwapAngrAndHP(target);
        }
    }
}