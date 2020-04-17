using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_602b",
  "name": [
    "青玉秘藏",
    "Jade Stash"
  ],
  "text": [
    "将三张“青玉护符”洗入你的\n牌库。",
    "Shuffle 3 Jade Idols into your deck."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41408
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_602b : SimCard //* Jade Idol
	{
		// Shuffle 3 Jade Idols into your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.ownDeckSize += 3;
                p.evaluatePenality -= 11;
            }
            else p.enemyDeckSize += 3;
        }
    }
}