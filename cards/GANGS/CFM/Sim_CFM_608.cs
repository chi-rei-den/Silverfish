using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_608",
  "name": [
    "爆晶药水",
    "Blastcrystal Potion"
  ],
  "text": [
    "消灭一个随从，和你的一个法力水晶。",
    "Destroy a minion and one of your Mana Crystals."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40957
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_608 : SimCard //* Blastcrystal Potion
	{
		// Destroy a minion and one of your Mana Crystals.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            if (ownplay) p.ownMaxMana--;
            else p.enemyMaxMana--;
        }
    }
}