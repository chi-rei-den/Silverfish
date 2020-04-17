using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_048",
  "name": [
    "治疗波",
    "Healing Wave"
  ],
  "text": [
    "恢复#7点生命值。揭示双方牌库里的一张随从牌。如果你的牌法力值消耗较大，则恢复#14点生命值。",
    "Restore #7 Health. Reveal a minion in each deck. If yours costs more, Restore #14 instead."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2612
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_048 : SimCard //* Healing Wave
	{
		//Restore 7 Health. Reveal a minion in each deck. If yours costs more, Restore 14 instead.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(14) : p.getEnemySpellHeal(14);//optimistic
            p.minionGetDamageOrHeal(target, -heal);            
		}
	}
}