using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_830",
  "name": [
    "残暴的恐龙术士",
    "Cruel Dinomancer"
  ],
  "text": [
    "<b>亡语：</b>随机召唤一个你在本局对战中弃掉的友方随从。",
    "[x]<b>Deathrattle:</b> Summon a\nrandom minion you\ndiscarded this game."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41869
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_830 : SimTemplate //* Cruel Dinomancer
	{
		//Deathrattle: Summon a random minion you discarded this game.

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.callKid(CardIds.Collectible.Warlock.SilverwareGolem, m.zonepos-1, m.own); //Silverware Golem.
        }
	}
}