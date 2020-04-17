using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_596",
  "name": [
    "恶魔之火",
    "Demonfire"
  ],
  "text": [
    "对一个随从造成$2点伤害，如果该随从是友方恶魔，则改为使其获得+2/+2。",
    "Deal $2 damage to a minion. If it’s a friendly Demon, give it +2/+2 instead."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1142
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_596 : SimCard //demonfire
	{

//    fügt einem diener $2 schaden zu. wenn das ziel ein verbündeter dämon ist, erhält er stattdessen +2/+2.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target.handcard.card.race == 15 && ownplay == target.own)
            {
                p.minionGetBuffed(target, 2, 2);
            }
            else
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
                p.minionGetDamageOrHeal(target, dmg);
            }
        }


	}
}