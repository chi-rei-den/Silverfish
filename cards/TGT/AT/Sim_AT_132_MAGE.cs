using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_MAGE",
  "name": [
    "二级火焰冲击",
    "Fireblast Rank 2"
  ],
  "text": [
    "<b>英雄技能</b>\n造成$2点伤害。",
    "<b>Hero Power</b>\nDeal $2 damage."
  ],
  "cardClass": "MAGE",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2739
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_132_MAGE : SimCard //* Fireblast Rank 2
	{
		//Hero Power: Deal 2 damage.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}