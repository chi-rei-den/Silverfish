using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_619",
  "name": [
    "生而平等",
    "Equality"
  ],
  "text": [
    "将所有随从的生命值变为1。",
    "Change the Health of ALL minions to 1."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 756
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_619 : SimCard //* equality
	{
        //Change the Health of ALL minions to 1.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            foreach (Minion m in p.ownMinions)
            {
                p.minionSetLifetoX(m, 1);
            }
            foreach (Minion m in p.enemyMinions)
            {
                p.minionSetLifetoX(m, 1);
            }
		}
	}
}