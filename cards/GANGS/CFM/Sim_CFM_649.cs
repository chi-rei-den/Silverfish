using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_649",
  "name": [
    "暗金教信使",
    "Kabal Courier"
  ],
  "text": [
    "<b>战吼：</b>\n<b>发现</b>一张法师、牧师或术士卡牌。",
    "<b>Battlecry:</b> <b>Discover</b> a Mage, Priest, or Warlock card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40496
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_649 : SimCard //* Kabal Courier
	{
		// Battlecry: Discover a Mage, Priest or Warlock card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.shieldbearer, m.own, true);
        }
    }
}