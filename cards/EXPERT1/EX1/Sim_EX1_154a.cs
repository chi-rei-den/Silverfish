using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_154a",
  "name": [
    "阳炎之怒",
    "Solar Wrath"
  ],
  "text": [
    "对一个随从造成$3点伤害。",
    "Deal $3 damage to a minion."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 253
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_154a : SimCard //wrath
	{

//    fügt einem diener $3 schaden zu.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = 0;
            damage = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            p.minionGetDamageOrHeal(target, damage);
        }

	}
}