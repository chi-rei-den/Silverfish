using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "PRO_001b",
  "name": [
    "潜行者的伎俩",
    "Rogues Do It..."
  ],
  "text": [
    "造成$4点伤害。抽一张牌。",
    "Deal $4 damage. Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 4,
  "rarity": null,
  "set": "HOF",
  "collectible": null,
  "dbfId": 1845
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_PRO_001b : SimCard //* Rogues Do It...
    {
        //Deal $4 damage. Draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
        }
    }
}
