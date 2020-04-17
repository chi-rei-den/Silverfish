using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX12_04",
  "name": [
    "激怒",
    "Enrage"
  ],
  "text": [
    "在本回合中，使你的英雄获得+6攻击力。",
    "Give your hero +6 Attack this turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1893
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX12_04 : SimCard //* Enrage
	{
		//Give your hero +6 Attack this turn.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetTempBuff(ownplay ? p.ownHero : p.enemyHero, 6, 0);
        }
    }
}