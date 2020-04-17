using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_015",
  "name": [
    "暗色炸弹",
    "Darkbomb"
  ],
  "text": [
    "造成$3点伤害。",
    "Deal $3 damage."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2093
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_015
        : SimCard //Darkbomb
    {

        //   Deal $3 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
        }


    }

}