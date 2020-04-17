using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX7_03",
  "name": [
    "重压打击",
    "Unbalancing Strike"
  ],
  "text": [
    "<b>英雄技能</b>\n造成3点伤害。",
    "<b>Hero Power</b>\nDeal 3 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1870
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX7_03 : SimCard //* Unbalancing Strike
	{
		// Hero Power: Deal 3 damage.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}