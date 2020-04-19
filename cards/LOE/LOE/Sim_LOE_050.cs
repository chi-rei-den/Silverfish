using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_050",
  "name": [
    "骑乘迅猛龙",
    "Mounted Raptor"
  ],
  "text": [
    "<b>亡语：</b>随机召唤一个法力值消耗为（1）的随从。",
    "<b>Deathrattle:</b> Summon a random 1-Cost minion."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2922
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_050 : SimTemplate //* Mounted Raptor
	{
        //Deathrattle: Summon a random 1-Cost minion.

        SimCard kid = CardIds.Collectible.Priest.TwilightWhelp; //Twilight Whelp

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos - 1, m.own);
        }
    }
}