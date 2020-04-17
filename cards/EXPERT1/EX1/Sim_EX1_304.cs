using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_304",
  "name": [
    "虚空恐魔",
    "Void Terror"
  ],
  "text": [
    "<b>战吼：</b>消灭该随从两侧的随从，并获得他们的攻击力和生命值。",
    "[x]<b>Battlecry:</b> Destroy both\nadjacent minions and gain\n their Attack and Health."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1221
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_304 : SimCard //* Void Terror
	{
        //Battlecry: Destroy the minions on either side of this minion and gain their Attack and Health.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;

            int angr = 0;
            int hp = 0;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    angr += m.Angr;
                    hp += m.Hp;
                    p.minionGetDestroyed(m);
                }
            }
            p.minionGetBuffed(own, angr, hp);
		}
	}
}