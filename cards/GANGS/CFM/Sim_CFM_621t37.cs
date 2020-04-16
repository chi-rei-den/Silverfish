using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t37",
  "name": [
    "亡灵腐液",
    "Ichor of Undeath"
  ],
  "text": [
    "召唤一个在本局对战中死亡的友方随从。",
    "Summon a friendly minion that died this game."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 42068
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t37 : SimTemplate //* Ichor of Undeath
	{
		// Summon a friendly minion that died this game.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			if (p.OwnLastDiedMinion != CardDB.cardIDEnum.None)
			{
				p.callKid(CardDB.Instance.getCardDataFromID(p.OwnLastDiedMinion), pos, ownplay, false); //presurmise - OwnLastDiedMinion also for enemy
			}
        }
    }
}