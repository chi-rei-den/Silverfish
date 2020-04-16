using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_321",
  "name": [
    "污手街情报员",
    "Grimestreet Informant"
  ],
  "text": [
    "<b>战吼：</b><b>发现</b>一张\n猎人、圣骑士或战士卡牌。",
    "[x]<b>Battlecry:</b> <b>Discover</b> a\nHunter, Paladin, or Warrior\ncard."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40474
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_321 : SimTemplate //* Grimestreet Informant
	{
		// Battlecry: Discover a Hunter, Paladin or Warrior card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.shieldbearer, m.own, true);
        }
    }
}