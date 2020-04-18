using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA09_2_TB",
  "name": [
    "打开大门",
    "Open the Gates"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤三个1/1的雏龙。",
    "<b>Hero Power</b>\nSummon three 1/1 Whelps."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 36721
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA09_2_TB : SimTemplate //* Open the Gates
	{
		// Hero Power: Summon three 1/1 Whelps. Get a new Hero Power.

		Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.OpentheGates_WhelpTokenBRS;//1/1Whelp
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
            p.callKid(kid, place, ownplay);
            p.callKid(kid, place, ownplay);
        }
	}
}