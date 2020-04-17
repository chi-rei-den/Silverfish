using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_WARRIOR",
  "name": [
    "铜墙铁壁！",
    "Tank Up!"
  ],
  "text": [
    "<b>英雄技能</b>\n获得4点护甲值。",
    "<b>Hero Power</b>\nGain 4 Armor."
  ],
  "cardClass": "WARRIOR",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2745
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_132_WARRIOR : SimCard //* Tank Up!
	{
		//Hero Power. Gain 4 Armor.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 4);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 4);
            }
		}
	}
}