using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "BOT_910",
  "name": [
    "亮石技师",
    "Glowstone Technician"
  ],
  "text": [
    "<b>战吼：</b>使你手牌中的所有随从牌获得+2/+2。",
    "<b>Battlecry:</b> Give all minions in your hand +2/+2."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 48989
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BOT_910 : SimTemplate //* 亮石技师 Glowstone Technician
	{
		//<b>Battlecry:</b> Give all minions in your hand +2/+2.
		//<b>战吼：</b>使你手牌中的所有随从牌获得+2/+2。
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{

foreach (Handmanager.Handcard hc in p.owncards)
{
if (hc.card.type == CardDB.cardtype.MOB)
{
hc.addattack+=2;
hc.addHp+=2;
}
}
}

		



	}
}