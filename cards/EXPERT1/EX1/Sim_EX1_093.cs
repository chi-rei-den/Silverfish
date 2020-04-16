using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_093",
  "name": [
    "阿古斯防御者",
    "Defender of Argus"
  ],
  "text": [
    "<b>战吼：</b>使相邻的随从获得+1/+1和<b>嘲讽</b>。",
    "<b>Battlecry:</b> Give adjacent minions +1/+1 and <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 763
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_093 : SimTemplate //* defenderofargus
	{
        //Battlecry: Give adjacent minions +1/+1 and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    p.minionGetBuffed(m, 1, 1);
                    if (!m.taunt)
                    {
                        m.taunt = true;
                        if (m.own) p.anzOwnTaunt++;
                        else p.anzEnemyTaunt++;
                    }
                }
            }
		}
	}
}