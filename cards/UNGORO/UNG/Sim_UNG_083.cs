using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_083",
  "name": [
    "魔暴龙蛋",
    "Devilsaur Egg"
  ],
  "text": [
    "<b>亡语：</b>召唤一个5/5的魔暴龙。",
    "<b>Deathrattle:</b> Summon a 5/5 Devilsaur."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41259
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_083 : SimTemplate //* Devilsaur Egg
	{
		//Deathrattle: Summon a 5/5 Devilsaur.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.DevilsaurEgg_DevilsaurToken; //5/5 Devilsaur
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos-1, m.own);
        }
	}
}