using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_591",
  "name": [
    "奥金尼灵魂祭司",
    "Auchenai Soulpriest"
  ],
  "text": [
    "你的恢复生命值的牌和技能改为造成等量的伤害。",
    "Your cards and powers that restore Health now deal damage instead."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "HOF",
  "collectible": true,
  "dbfId": 237
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_591 : SimCard //auchenaisoulpriest
	{

//    eure karten und fähigkeiten, die leben wiederherstellen, verursachen stattdessen nun schaden.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnAuchenaiSoulpriest++;
            }
            else
            {
                p.anzEnemyAuchenaiSoulpriest++;
            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnAuchenaiSoulpriest--;
            }
            else
            {
                p.anzEnemyAuchenaiSoulpriest--;
            }
        }


	}
}