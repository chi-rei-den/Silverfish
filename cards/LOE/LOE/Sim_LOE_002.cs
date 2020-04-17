using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_002",
  "name": [
    "老旧的火把",
    "Forgotten Torch"
  ],
  "text": [
    "造成$3点伤害。将一张可造成6点伤害的“炽烈的火把”洗入你的牌库。",
    "Deal $3 damage. Shuffle a 'Roaring Torch' into your deck that deals 6 damage."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2874
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_002 : SimCard //* Forgotten Torch
	{
		//Deal 3 damage. Shuffle a 'Roaring Torch' into your deck that deals 6 damage.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay)
			{
				p.ownDeckSize++;
				p.evaluatePenality -= 5;
			}
            else p.enemyDeckSize++;
		}
	}
}