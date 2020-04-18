using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_854",
  "name": [
    "琥口脱险",
    "Free From Amber"
  ],
  "text": [
    "<b>发现</b>一张法力值消耗大于或等于（8）点的随从牌，并召唤该随从。",
    "<b>Discover</b> a minion that costs (8) or more. Summon it."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 8,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 42009
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_854 : SimTemplate //* Free From Amber
	{
		//Discover a minion that costs (8) or more. Summon it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (p.ownHeroHasDirectLethal()) p.callKid(CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.AT_125), pos, ownplay, false);
            else p.callKid(CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.AT_120), pos, ownplay, false);
        }
    }
}