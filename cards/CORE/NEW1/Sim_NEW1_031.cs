using Chireiden.Silverfish;
using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_031",
  "name": [
    "动物伙伴",
    "Animal Companion"
  ],
  "text": [
    "随机召唤一个野兽伙伴。",
    "Summon a random Beast Companion."
  ],
  "CardClass": "HUNTER",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 437
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NEW1_031 : SimTemplate //* animalcompanion
	{
        //Summon a random Beast Companion.

        SimCard kid = CardIds.NonCollectible.Hunter.Misha;//misha
        
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)?  p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
		}

	}
}