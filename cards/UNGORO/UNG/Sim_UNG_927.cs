using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_927",
  "name": [
    "基因转接",
    "Sudden Genesis"
  ],
  "text": [
    "复制所有受伤的友方随从。",
    "Summon copies of your damaged minions."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 5,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41407
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_927 : SimCard //* Sudden Genesis
	{
		//Summon copies of your damaged minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            List<Minion> temp2;
            int pos = temp.Count;
			bool spawnKid = false;
            if (pos > 0 && pos < 7)
            {
                foreach (Minion m in temp.ToArray())
                {
					if (!m.wounded) continue;
                    p.callKid(m.handcard.card, pos, ownplay, spawnKid);
					spawnKid = true;
                    temp2 = (ownplay) ? p.ownMinions : p.enemyMinions;
                    temp2[pos].setMinionToMinion(m);
                    pos++;
                    if (pos > 6) break;
                }
            }
        }
    }
}