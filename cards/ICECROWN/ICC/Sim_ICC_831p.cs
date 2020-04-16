using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_831p",
  "name": [
    "生命虹吸",
    "Siphon Life"
  ],
  "text": [
    "<b>英雄技能</b>\n<b>吸血</b>，造成$3点\n伤害。",
    "<b>Hero Power</b>\n<b>Lifesteal</b>\nDeal $3 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43181
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_831p: SimTemplate //* Siphon Life
    {
        // Hero Power: Lifesteal. Deal 3 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);

            int oldHp = target.Hp;
            p.minionGetDamageOrHeal(target, dmg);
            if (oldHp > target.Hp) p.applySpellLifesteal(oldHp - target.Hp, ownplay);
        }
    }
}