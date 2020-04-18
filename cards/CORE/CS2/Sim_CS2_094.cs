using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_094",
  "name": [
    "愤怒之锤",
    "Hammer of Wrath"
  ],
  "text": [
    "造成$3点伤害。抽一张牌。",
    "Deal $3 damage.\nDraw a card."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 250
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_094 : SimTemplate //hammerofwrath
	{

//    verursacht $3 schaden. zieht eine karte.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
		}

	}
}