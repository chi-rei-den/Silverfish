using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_017",
  "name": [
    "复活术",
    "Resurrect"
  ],
  "text": [
    "随机召唤一个在本局对战中死亡的友方随从。",
    "Summon a random friendly minion that died this game."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2298
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_017 : SimTemplate //* Resurrect
	{
		// Summon a random friendly minion that died this game.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (p.ownMaxMana >= 6)
            {
                int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID((p.OwnLastDiedMinion == CardDB.cardIDEnum.None) ? CardDB.cardIDEnum.EX1_345t : p.OwnLastDiedMinion); // Shadow of Nothing 0:1 or ownMinion
                p.callKid(kid, posi, ownplay, false);
            }
		}
	}
}