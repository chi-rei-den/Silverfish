using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_049",
  "name": [
    "剧毒箭矢",
    "Toxic Arrow"
  ],
  "text": [
    "对一个随从造成$2点伤害，如果\n它依然存活，则获得<b>剧毒</b>。",
    "Deal $2 damage to a minion. If it survives, give it <b>Poisonous</b>."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42648
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_049 : SimTemplate //* Toxic Arrow
    {
        // Deal 2 damage to a minion. If it survives, give it Poisonous.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            p.minionGetDamageOrHeal(target, dmg);
            if (target.Hp > 0) target.poisonous = true;
        }
    }
}