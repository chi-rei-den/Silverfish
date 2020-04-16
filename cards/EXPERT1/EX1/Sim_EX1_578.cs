using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_578",
  "name": [
    "野蛮之击",
    "Savagery"
  ],
  "text": [
    "对一个随从造成等同于你的英雄攻击力的伤害。",
    "Deal damage equal to your hero's Attack to a minion."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 481
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_578 : SimTemplate //savagery
	{

//    fügt einem diener schaden zu, der dem angriff eures helden entspricht.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(p.ownHero.Angr) : p.getEnemySpellDamageDamage(p.enemyHero.Angr);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}