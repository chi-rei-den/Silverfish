using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621",
  "name": [
    "卡扎库斯",
    "Kazakus"
  ],
  "text": [
    "<b>战吼：</b>如果你的牌库里没有相同的牌，则为你创建一个自定义\n法术。",
    "[x]<b>Battlecry:</b> If your deck\nhas no duplicates,\n create a custom spell."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40408
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621 : SimCard //* Kazakus
	{
		// Battlecry: If your deck has no duplicates, create a custom spell.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own && p.prozis.noDuplicates) p.drawACard(CardDB.cardName.thecoin, m.own, true);
        }
    }
}