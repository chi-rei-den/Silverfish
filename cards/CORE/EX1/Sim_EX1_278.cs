using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_278",
  "name": [
    "毒刃",
    "Shiv"
  ],
  "text": [
    "造成$1点伤害，抽一张牌。",
    "Deal $1 damage.\nDraw a card."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 573
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_278 : SimCard //shiv
	{

//    verursacht $1 schaden. zieht eine karte.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
           p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}

	}
}