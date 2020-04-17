using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_940t8",
  "name": [
    "希望守护者阿玛拉",
    "Amara, Warden of Hope"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>\n将你英雄的生命值变为40。",
    "[x]<b>Taunt</b>\n<b>Battlecry:</b> Set your\nhero's Health to 40."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41950
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_940t8 : SimCard //* Amara, Warden of Hope
	{
		//Taunt. Battlecry: Set your hero's Health to 40.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own) p.ownHero.Hp = 40;
			else p.enemyHero.Hp = 40;
		}
	}
}