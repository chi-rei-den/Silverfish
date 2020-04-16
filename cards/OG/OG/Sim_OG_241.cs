using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_241",
  "name": [
    "着魔村民",
    "Possessed Villager"
  ],
  "text": [
    "<b>亡语：</b>召唤一个1/1的暗影兽。",
    "<b>Deathrattle:</b> Summon a 1/1 Shadowbeast."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38774
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_241 : SimTemplate //* Possessed Villager
	{
		//Deathrattle: Summon a 1/1 Shadowbeast.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_241a);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos-1, m.own);
        }
	}
}