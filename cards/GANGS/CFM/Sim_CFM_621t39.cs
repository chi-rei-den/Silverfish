using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t39",
  "name": [
    "亡灵腐液",
    "Ichor of Undeath"
  ],
  "text": [
    "召唤三个在本局对战中死亡的友方随从。",
    "Summon 3 friendly minions that died this game."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 42070
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t39 : SimTemplate //* Ichor of Undeath
	{
		// Summon 3 friendly minions that died this game.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			if (p.OwnLastDiedMinion != SimCard.None)
			{
				p.callKid((p.OwnLastDiedMinion), pos, ownplay, false); //presurmise - OwnLastDiedMinion also for enemy
				p.callKid((p.OwnLastDiedMinion), pos, ownplay);
				p.callKid((p.OwnLastDiedMinion), pos, ownplay);
			}
        }
    }
}