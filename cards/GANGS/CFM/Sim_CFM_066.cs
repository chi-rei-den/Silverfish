using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_066",
  "name": [
    "暗金教侍从",
    "Kabal Lackey"
  ],
  "text": [
    "<b>战吼：</b>\n在本回合中，你使用的下一个<b>奥秘</b>的法力值消耗为（0）点。",
    "[x]<b>Battlecry:</b> The next <b>Secret</b>\nyou play this turn costs (0)."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40299
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_066 : SimCard //* Kabal Lackey
	{
		// Battlecry: The next Secret you play this turn costs (0).

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own) p.nextSecretThisTurnCost0 = true;
        }
    }
}