using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_957",
  "name": [
    "恐角龙宝宝",
    "Direhorn Hatchling"
  ],
  "text": [
    "<b>嘲讽，亡语：</b>\n将一张6/9并具有<b>嘲讽</b>的“恐角龙头领”洗入你的牌库。",
    "<b>Taunt</b>\n<b>Deathrattle:</b> Shuffle a 6/9 Direhorn with <b>Taunt</b> into your deck."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41890
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_957 : SimCard //* Direhorn Hatchling
	{
		//Taunt. Deathrattle: Shuffle a 6/9 Direhorn with Taunt into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.ownDeckSize++;
            else p.enemyDeckSize++;
        }
    }
}