using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_021",
  "name": [
    "冰冻药水",
    "Freezing Potion"
  ],
  "text": [
    "<b>冻结</b>一个敌人。",
    "<b>Freeze</b> an enemy."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 0,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40324
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_021 : SimTemplate //* Freezing Potion
	{
		// Freeze an enemy.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetFrozen(target);
        }
    }
}
