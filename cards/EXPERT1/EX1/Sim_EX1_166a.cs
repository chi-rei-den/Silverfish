using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_166a",
  "name": [
    "月火术",
    "Moonfire"
  ],
  "text": [
    "造成2点伤害。",
    "Deal 2 damage."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 4,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 987
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_166a : SimTemplate //* moonfire
	{
        //Deal 2 damage.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}