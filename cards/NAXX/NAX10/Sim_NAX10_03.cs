using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX10_03",
  "name": [
    "仇恨打击",
    "Hateful Strike"
  ],
  "text": [
    "<b>英雄技能</b>\n消灭一个随从。",
    "<b>Hero Power</b>\nDestroy a minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 4,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1886
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX10_03 : SimCard //* Hateful Strike
	{
		// Hero Power: Destroy a minion.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }
    }
}