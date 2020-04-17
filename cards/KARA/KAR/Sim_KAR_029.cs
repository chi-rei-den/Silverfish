using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_029",
  "name": [
    "符文蛋",
    "Runic Egg"
  ],
  "text": [
    "<b>亡语：</b>抽一张牌。",
    "<b>Deathrattle:</b> Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39433
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_029 : SimCard //* Runic Egg
	{
		//Deathrattle: Draw a card.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.None, m.own);
        }
	}
}