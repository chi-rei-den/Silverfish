using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX5_02H",
  "name": [
    "爆发",
    "Eruption"
  ],
  "text": [
    "<b>英雄技能</b>\n对位于最左边的敌方随从造成3点\n伤害。",
    "<b>Hero Power</b>\nDeal 3 damage to the left-most enemy minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2117
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX5_02H : SimCard //* Eruption
	{
		//Hero Power: Deal 3 damage to the left-most enemy 
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            if (temp.Count < 1) return;
            else
			{
				int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
				target = temp[0];
				foreach (Minion m in temp)
				{
					if (m.zonepos < target.zonepos) target = m;
				}
				p.minionGetDamageOrHeal(target, dmg);
			}
		}
	}
}