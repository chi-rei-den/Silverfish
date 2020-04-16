using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_408",
  "name": [
    "致死打击",
    "Mortal Strike"
  ],
  "text": [
    "造成$4点伤害；如果你的生命值小于或等于12点，则改为造成$6点伤害。",
    "Deal $4 damage. If you have 12 or less Health, deal $6 instead."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 804
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_408 : SimTemplate //mortalstrike
	{

//    verursacht $4 schaden. verursacht stattdessen $6 schaden, wenn euer held max. 12 leben hat.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = 0;

            if (ownplay)
            {
                dmg = (p.ownHero.Hp <= 12) ? p.getSpellDamageDamage(6) : p.getSpellDamageDamage(4);
            }
            else
            {
                dmg = (p.enemyHero.Hp <= 12) ? p.getEnemySpellDamageDamage(6) : p.getEnemySpellDamageDamage(4);
            }
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}