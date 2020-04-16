using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_316",
  "name": [
    "力量的代价",
    "Power Overwhelming"
  ],
  "text": [
    "使一个友方随从获得+4/+4，该随从会在回合结束时死亡。",
    "Give a friendly minion +4/+4 until end of turn. Then, it dies. Horribly."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "HOF",
  "collectible": true,
  "dbfId": 846
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_316 : SimTemplate //poweroverwhelming
	{
        //Give a friendly minion +4/+4 until end of turn. Then, it dies. Horribly.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 4, 4);
            if (ownplay)
            {
                target.destroyOnOwnTurnEnd = true;
            }
            else
            {
                target.destroyOnEnemyTurnEnd = true;
            }
		}
	}
}