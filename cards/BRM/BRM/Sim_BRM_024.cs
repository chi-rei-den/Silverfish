using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_024",
  "name": [
    "龙人打击者",
    "Drakonid Crusher"
  ],
  "text": [
    "<b>战吼：</b>如果你对手的生命值小于或等于15点，便获得+3/+3。",
    "<b>Battlecry:</b> If your opponent has 15 or less Health, gain +3/+3."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2257
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_024 : SimCard //* Drakonid Crusher
	{
		//	Battlecry: If your opponent has 15 or less Health, gain +3/+3.
	
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int heroHealth = m.own ? p.enemyHero.Hp : p.ownHero.Hp;
			if(heroHealth <= 15) p.minionGetBuffed(m, 3, 3);
        }
	}
}