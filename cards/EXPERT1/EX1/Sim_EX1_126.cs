using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_126",
  "name": [
    "背叛",
    "Betrayal"
  ],
  "text": [
    "使一个敌方随从对其相邻的随从\n造成等同于其攻击力的伤害。",
    "Force an enemy minion to deal its damage to the minions next to it."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 282
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_126 : SimTemplate //betrayal
	{

//    zwingt einen feindlichen diener, seinen schaden benachbarten dienern zuzufügen.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            //attack right neightbor
            if (target.Angr>0)
            {
                int dmg = target.Angr;
                List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.zonepos + 1 == target.zonepos || m.zonepos-1 == target.zonepos)
                    {
                        /*int oldhp = m.Hp;
                        p.minionGetDamageOrHeal(m, dmg);
                        if (!target.silenced && (target.handcard.card.name == CardIds.Collectible.Mage.WaterElemental ||target.handcard.card.name == CardIds.Collectible.Mage.Snowchugger) && m.Hp < oldhp) m.frozen=true;
                        if (!target.silenced && m.Hp < oldhp && target.poisonous) p.minionGetDestroyed(m);*/
                        p.minionAttacksMinion(target, m, true);
                    }
                }

            }

		}

	}
}