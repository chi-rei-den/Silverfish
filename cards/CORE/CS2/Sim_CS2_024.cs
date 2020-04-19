using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_024",
  "name": [
    "寒冰箭",
    "Frostbolt"
  ],
  "text": [
    "对一个角色造成$3点伤害，并使其<b>冻结</b>。",
    "Deal $3 damage to a character and <b>Freeze</b> it."
  ],
  "CardClass": "MAGE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 662
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_024 : SimTemplate //Frostbolt
    {
        //Deal $3 damage to a character and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetFrozen(target);
            p.minionGetDamageOrHeal(target,dmg);
        }
    }
}
