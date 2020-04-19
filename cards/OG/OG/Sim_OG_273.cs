using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_273",
  "name": [
    "惩黑除恶",
    "Stand Against Darkness"
  ],
  "text": [
    "召唤五个1/1的白银之手新兵。",
    "Summon five 1/1 Silver Hand Recruits."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 5,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38843
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_273 : SimTemplate //* Stand Against Darkness
	{
		//Summon five 1/1 Silver Hand Recruits.
		
        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, pos, ownplay, false);
            for (int i = 0; i < 4; i++) p.callKid(kid, pos, ownplay);
        }
    }
}
