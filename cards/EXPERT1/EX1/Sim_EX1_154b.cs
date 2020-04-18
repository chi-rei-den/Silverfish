using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_154b",
  "name": [
    "自然之怒",
    "Nature's Wrath"
  ],
  "text": [
    "对一个随从造成$1点伤害，抽一张牌。",
    "Deal $1 damage to a minion. Draw a card."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 137
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_154b : SimTemplate //wrath
	{

//    fügt einem diener $1 schaden zu. zieht eine karte.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            //this.owncarddraw++;

            p.minionGetDamageOrHeal(target, damage);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
        }

	}
}