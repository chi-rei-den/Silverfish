using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_034_H2",
  "name": [
    "火焰冲击",
    "Fireblast"
  ],
  "text": [
    "<b>英雄技能</b>\n造成$1点伤害。",
    "<b>Hero Power</b>\nDeal $1 damage."
  ],
  "cardClass": "MAGE",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "HERO_SKINS",
  "collectible": null,
  "dbfId": 39791
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_034_H2 : SimCard //* Fireblast
	{
		//Hero Power: Deal 1 damage.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}