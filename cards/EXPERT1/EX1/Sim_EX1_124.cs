using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_124",
  "name": [
    "刺骨",
    "Eviscerate"
  ],
  "text": [
    "造成$2点伤害；<b>连击：</b>改为造成$4点伤害。",
    "Deal $2 damage. <b>Combo:</b> Deal $4 damage instead."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 904
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_124 : SimTemplate //eviscerate
	{

//    verursacht $2 schaden. combo:/ verursacht stattdessen $4 schaden.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            if (p.cardsPlayedThisTurn == 0) dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}