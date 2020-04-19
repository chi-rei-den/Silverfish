using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_173",
  "name": [
    "星火术",
    "Starfire"
  ],
  "text": [
    "造成$5点伤害。抽一张牌。",
    "Deal $5 damage.\nDraw a card."
  ],
  "CardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 823
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_173 : SimTemplate //starfire
	{

//    verursacht $5 schaden. zieht eine karte.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
            //this.owncarddraw++;
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
		}

	}
}