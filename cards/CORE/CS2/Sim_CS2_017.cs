using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_017",
  "name": [
    "变形",
    "Shapeshift"
  ],
  "text": [
    "<b>英雄技能</b>\n本回合+1攻击力。  +1护甲值。",
    "<b>Hero Power</b>\n+1 Attack this turn.\n+1 Armor."
  ],
  "cardClass": "DRUID",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 1123
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_017 : SimCard //shapeshift
	{

//    heldenfähigkeit/\n+1 angriff in diesem zug.\n+1 rüstung.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetTempBuff(p.ownHero, 1, 0);
                p.minionGetArmor(p.ownHero,1);
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 1, 0);
                p.minionGetArmor(p.enemyHero,1);
            }
        }

	}
}