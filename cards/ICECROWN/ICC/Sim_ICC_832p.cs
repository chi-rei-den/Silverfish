using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_832p",
  "name": [
    "瘟疫领主",
    "Plague Lord"
  ],
  "text": [
    "<b>英雄技能</b>\n<b>抉择：</b>在本回合中获得+3攻击力；或者获得3点护甲值。",
    "[x]<b>Hero Power</b>\n<b>Choose One -</b> +3 Attack\nthis turn; or Gain 3 Armor."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43182
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_832p: SimCard //* Plague Lord
    {
        // Hero Power: Choose One - +3 Attack this turn; or Gain 3 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (ownplay) p.minionGetTempBuff(p.ownHero, 3, 0);
                else p.minionGetTempBuff(p.enemyHero, 3, 0);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (ownplay) p.minionGetArmor(p.ownHero, 3);
                else p.minionGetArmor(p.enemyHero, 3);
            }
        }
    }
}