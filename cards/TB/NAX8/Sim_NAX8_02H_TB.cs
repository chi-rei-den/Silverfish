using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX8_02H_TB",
  "name": [
    "收割",
    "Harvest"
  ],
  "text": [
    "<b>英雄技能</b>\n抽一张牌。获得一个法力水晶。",
    "<b>Hero Power</b>\nDraw a card. Gain a Mana Crystal."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 36744
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX8_02H_TB : SimTemplate //* Harvest heroic
	{

//    Hero PowerDraw a card. Gain a Mana Crystal.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay);
			
			p.mana = Math.Min(10, p.mana++);
			if (ownplay)
			{
				p.ownMaxMana = Math.Min(10, p.ownMaxMana++);
			}
			else
			{
				p.enemyMaxMana = Math.Min(10, p.enemyMaxMana++);
			}
        }
	}
}