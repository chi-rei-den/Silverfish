using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_062",
  "name": [
    "天降蛛群",
    "Ball of Spiders"
  ],
  "text": [
    "召唤三个1/1的结网蛛。",
    "Summon three 1/1 Webspinners."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2483
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_062 : SimTemplate //* Ball of Spiders
    {
		//Summon three 1/1 Webspinners.
		
        SimCard kid = CardIds.Collectible.Hunter.Webspinner;//Webspinner

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, place, ownplay, false);
            p.callKid(kid, place, ownplay);
            p.callKid(kid, place, ownplay);
		}
	}
}