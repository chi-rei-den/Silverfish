using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_235",
  "name": [
    "北郡牧师",
    "Northshire Cleric"
  ],
  "text": [
    "每当一个随从获得治疗时，抽一张牌。",
    "Whenever a minion is healed, draw a card."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "HOF",
  "collectible": true,
  "dbfId": 1650
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_235 : SimCard //* northshirecleric
	{
        //Whenever a minion is healed, draw a card.

        public override void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, int minionsGotHealed)
        {
            for (int i = 0; i < minionsGotHealed; i++)
            {
                p.drawACard(CardDB.cardIDEnum.None, triggerEffectMinion.own);
            }
        }
	}
}