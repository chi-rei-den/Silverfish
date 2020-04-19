using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_160",
  "name": [
    "野性之力",
    "Power of the Wild"
  ],
  "text": [
    "<b>抉择：</b>使你的所有随从获得+1/+1；或者召唤一个3/2的\n猎豹。",
    "<b>Choose One -</b> Give your minions +1/+1; or Summon a 3/2 Panther."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 503
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_160 : SimTemplate //* powerofthewild
	{
        //Choose One - Give your minions +1/+1; or Summon a 3/2 Panther.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Druid.PoweroftheWild_PantherToken;//panther

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                p.allMinionOfASideGetBuffed(ownplay, 1, 1);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, pos, ownplay, false);
                
            }
		}
	}
}