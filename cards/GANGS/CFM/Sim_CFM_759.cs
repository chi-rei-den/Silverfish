using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_759",
  "name": [
    "海象人执法官",
    "Meanstreet Marshal"
  ],
  "text": [
    "<b>亡语：</b>如果该随从的攻击力大于或等于2，抽一张牌。",
    "<b>Deathrattle:</b> If this minion has 2 or more Attack, draw a card."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 1,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40577
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_759 : SimCard //* Meanstreet Marshal
	{
		// Deathrattle: If this minion has 2 or more Attack, draw a card.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.Angr >= 2) p.drawACard(CardDB.cardIDEnum.None, m.own);
        }
    }
}