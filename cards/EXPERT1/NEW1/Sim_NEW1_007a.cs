using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_007a",
  "name": [
    "星辰漂流",
    "Stellar Drift"
  ],
  "text": [
    "对所有敌方随从造成$2点伤害。",
    "Deal $2 damage to all enemy minions."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1161
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_007a : SimTemplate //starfall choice left
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
        }

    }
}