using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA17_5_TB",
  "name": [
    "白骨爪牙",
    "Bone Minions"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤两个2/1的白骨结构体。",
    "<b>Hero Power</b>\nSummon two 2/1 Bone Constructs."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 35568
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA17_5_TB : SimTemplate //* Bone Minions
	{
		// Hero Power: Summon two 2/1 Bone Constructs.

		Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.BoneConstruct;//2/1Bone Construct
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
            p.callKid(kid, place, ownplay);
        }
	}
}