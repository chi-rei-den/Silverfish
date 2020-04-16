using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_174",
  "name": [
    "无面蹒跚者",
    "Faceless Shambler"
  ],
  "text": [
    "<b>嘲讽</b>，<b>战吼：</b>复制一个友方随从的攻击力和生命值。",
    "<b>Taunt</b>\n<b>Battlecry:</b> Copy a friendly minion's Attack and Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38569
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_174 : SimTemplate //* Faceless Shambler
	{
		//Battlecry: Copy a friendly minion's Attack and Health.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
			{
				own.Hp = target.Hp;
				own.Angr = target.Angr;
			}
		}
	}
}