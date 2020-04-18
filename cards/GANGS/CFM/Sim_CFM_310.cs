using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_310",
  "name": [
    "神奇四鱼",
    "Call in the Finishers"
  ],
  "text": [
    "召唤四个1/1的鱼人。",
    "Summon four 1/1 Murlocs."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40419
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_310 : SimTemplate //* Call in the Finishers
	{
		// Summon four 1/1 Murlocs.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Shaman.CallintheFinishers_MurlocRazorgillToken; //1/1 Murloc Razorgill

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, pos, ownplay, false);
            p.callKid(kid, pos, ownplay);
            p.callKid(kid, pos, ownplay);
            p.callKid(kid, pos, ownplay);
        }
    }
}