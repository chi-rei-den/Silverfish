using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_002",
  "name": [
    "鬼灵爬行者",
    "Haunted Creeper"
  ],
  "text": [
    "<b>亡语：</b>召唤两只1/1的鬼灵蜘蛛。",
    "<b>Deathrattle:</b> Summon two 1/1 Spectral Spiders."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1781
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_002 : SimTemplate //* hauntedcreeper
	{
        //Deathrattle: Summon two 1/1 Spectral Spiders.

        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_002t);
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(c, m.zonepos-1, m.own);
            p.callKid(c, m.zonepos-1, m.own);
        }
	}
}