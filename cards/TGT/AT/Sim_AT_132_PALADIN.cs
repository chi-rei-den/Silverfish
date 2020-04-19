using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_PALADIN",
  "name": [
    "白银之手",
    "The Silver Hand"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤两个1/1的白银之手新兵。",
    "<b>Hero Power</b>\nSummon two 1/1 Recruits."
  ],
  "cardClass": "PALADIN",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2740
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_132_PALADIN : SimTemplate //* The Silver Hand
	{
		//Hero Power. Summon two 1/1 Recruits.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken;//silverhandrecruit

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
            p.callKid(kid, place, ownplay);
        }
	}
}