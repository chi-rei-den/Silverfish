using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_611",
  "name": [
    "血怒药水",
    "Bloodfury Potion"
  ],
  "text": [
    "使一个随从获得+3攻击力。如果该随从是恶魔，还会获得+3生命值。",
    "[x]Give a minion +3 Attack.\nIf it's a Demon, also\ngive it +3 Health."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40393
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_611 : SimTemplate //* Bloodfury Potion
	{
		// Give a minion +3 Attack. If it's a Demon, also give it +3 Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int hpbaff = 0;
            if ((TAG_RACE)target.handcard.card.race == TAG_RACE.DEMON) hpbaff = 3;
            p.minionGetBuffed(target, 3, hpbaff);
        }
    }
}