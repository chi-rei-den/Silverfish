using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_051",
  "name": [
    "元素毁灭",
    "Elemental Destruction"
  ],
  "text": [
    "对所有随从造成$4到$5点伤害。<b>过载：</b>（5）",
    "Deal $4-$5 damage to all minions. <b>Overload:</b> (5)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2620
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_051 : SimCard //* Elemental Destruction
	{
		//Deal 4-5 damage to all minions. Overload: (5)

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.allMinionsGetDamage(dmg);
            if (ownplay) p.ueberladung += 5;
		}
	}
}