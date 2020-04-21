using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_019",
  "name": [
    "恶魔之心",
    "Demonheart"
  ],
  "text": [
    "对一个随从造成$5点伤害，如果该随从是友方恶魔，则改为使其获得+5/+5。",
    "Deal $5 damage to a minion.  If it's a friendly Demon, give it +5/+5 instead."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 5,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1985
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_019 : SimTemplate //Demonheart
    {

        //    Deal $5 damage to a minion.  If it's a friendly Demon, give it +5/+5 instead.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target.own == ownplay && target.handcard.card.Race == Race.DEMON)
            {
                //give it +5/+5
                p.minionGetBuffed(target, 5, 5);
            }
            else
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);

                p.minionGetDamageOrHeal(target, dmg);
            }
        }

    }

}