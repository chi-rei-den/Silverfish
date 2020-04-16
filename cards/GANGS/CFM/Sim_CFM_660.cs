using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_660",
  "name": [
    "狂热铸魂者",
    "Manic Soulcaster"
  ],
  "text": [
    "<b>战吼：</b>选择一个友方随从，将它的一张复制洗入你的牌库。",
    "<b>Battlecry:</b> Choose a friendly minion. Shuffle a copy into your deck."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40935
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_660 : SimTemplate //* Manic Soulcaster
	{
		// Battlecry: Choose a friendly minion. Shuffle a copy into your deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                if (m.own) p.ownDeckSize++;
                else p.enemyDeckSize++;
            }
        }
    }
}