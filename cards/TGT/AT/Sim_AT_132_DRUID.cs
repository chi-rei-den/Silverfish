using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_DRUID",
  "name": [
    "恐怖变形",
    "Dire Shapeshift"
  ],
  "text": [
    "<b>英雄技能</b>\n本回合+2攻击力。+2护甲值。",
    "<b>Hero Power</b>\n+2 Attack this turn.\n+2 Armor."
  ],
  "cardClass": "DRUID",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2737
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_132_DRUID : SimTemplate //* Dire Shapeshift
	{
		//Hero Power. Gain 2 Armor and +2 Attack this turn.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetTempBuff(p.ownHero, 2, 0);
                p.minionGetArmor(p.ownHero,2);
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 2, 0);
                p.minionGetArmor(p.enemyHero,2);
            }
        }
	}
}