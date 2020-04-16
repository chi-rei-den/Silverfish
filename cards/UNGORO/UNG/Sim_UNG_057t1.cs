using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_057t1",
  "name": [
    "刀瓣",
    "Razorpetal"
  ],
  "text": [
    "造成$1点伤害。",
    "Deal $1 damage."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41206
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_057t1 : SimTemplate //* Razorpetal
	{
        //Deal $1 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}