using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_211c",
  "name": [
    "火之祈咒",
    "Invocation of Fire"
  ],
  "text": [
    "对敌方英雄造成6点伤害。",
    "Deal 6 damage to the enemy hero."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41335
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_211c : SimTemplate //* Invocation of Fire
	{
		//Deal 6 damage to the enemy hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);
            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
        }
    }
}