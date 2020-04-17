using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_050t",
  "name": [
    "雷霆震击",
    "Lightning Jolt"
  ],
  "text": [
    "<b>英雄技能</b>\n造成$2点伤害。",
    "<b>Hero Power</b>\nDeal $2 damage."
  ],
  "cardClass": "SHAMAN",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2803
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_050t : SimCard //* Lightning Jolt
	{
		//Hero Power: Deal $2 damage.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}