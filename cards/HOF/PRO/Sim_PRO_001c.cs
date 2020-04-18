using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "PRO_001c",
  "name": [
    "部落的力量",
    "Power of the Horde"
  ],
  "text": [
    "随机召唤一名部落勇士。",
    "Summon a random Horde Warrior."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 4,
  "rarity": null,
  "set": "HOF",
  "collectible": null,
  "dbfId": 1846
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_PRO_001c : SimTemplate //* powerofthehorde
	{
        //Summon a random Horde Warrior.
        Chireiden.Silverfish.SimCard kid = CardIds.Collectible.Neutral.TaurenWarrior;

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
		}
	}
}