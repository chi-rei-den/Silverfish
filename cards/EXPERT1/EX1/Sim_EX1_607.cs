using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_607",
  "name": [
    "怒火中烧",
    "Inner Rage"
  ],
  "text": [
    "对一个随从造成$1点伤害，该随从获得+2攻击力。",
    "Deal $1 damage to a minion and give it +2 Attack."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 0,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 22
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_607 : SimTemplate //innerrage
	{

//    fügt einem diener $1 schaden zu. der diener erhält +2 angriff.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
            p.minionGetTempBuff(target, 2,0);
		}

	}
}