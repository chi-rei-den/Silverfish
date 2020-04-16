using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_092",
  "name": [
    "麦迪文的男仆",
    "Medivh's Valet"
  ],
  "text": [
    "<b>战吼：</b>\n如果你控制一个<b>奥秘</b>，则造成3点伤害。",
    "<b>Battlecry:</b> If you control a <b>Secret</b>, deal 3 damage."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39767
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_092 : SimTemplate //* Medivh's Valet
	{
		//Battlecry: If you control a Secret, deal 3 damage.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetDamageOrHeal(target, 3);
		}
	}
}