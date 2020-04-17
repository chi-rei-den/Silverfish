using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_027",
  "name": [
    "派烙斯",
    "Pyros"
  ],
  "text": [
    "<b>亡语：</b>将该随从移回你的手牌，并变为法力值消耗为（6）点的6/6随从牌。",
    "<b>Deathrattle:</b> Return this to your hand as a 6/6 that costs (6)."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41162
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_027 : SimCard //* Pyros
	{
		//Deathrattle: Return this to your hand as a 6/6 that costs (6).

        public override void onDeathrattle(Playfield p, Minion m)
        {
		    p.drawACard(CardDB.cardIDEnum.UNG_027t2, m.own, true);
        }
	}
}