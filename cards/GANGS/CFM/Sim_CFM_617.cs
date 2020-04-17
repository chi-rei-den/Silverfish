using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_617",
  "name": [
    "天神唤梦者",
    "Celestial Dreamer"
  ],
  "text": [
    "<b>战吼：</b>如果你控制一个攻击力大于或等于5的随从，便获得+2/+2。",
    "[x]<b>Battlecry:</b> If you control a\nminion with 5 or more\nAttack, gain +2/+2."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40404
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_617 : SimCard //* Celestial Dreamer
	{
		// Battlecry: If a friendly minion has 5 or more attack, gain +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.Angr > 4)
                {
                    p.minionGetBuffed(m, 2, 2);
                    break;
                }
            }
        }
    }
}