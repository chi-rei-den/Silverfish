using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_834h",
  "name": [
    "剑刃风暴",
    "Bladestorm"
  ],
  "text": [
    "<b>英雄技能</b>\n对所有随从造成\n$1点伤害。",
    "<b>Hero Power</b>\n Deal $1 damage to all minions."
  ],
  "cardClass": "WARRIOR",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 45585
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_834h: SimTemplate //* Bladestorm
    {
        // Hero Power: Deal 1 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
            p.allMinionsGetDamage(dmg);
        }
    }
}