using Chireiden.Silverfish;
using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA17_5H",
  "name": [
    "白骨爪牙",
    "Bone Minions"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤两个4/2的白骨结构体。",
    "<b>Hero Power</b>\nSummon two 4/2 Bone Constructs."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2561
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA17_5H : SimTemplate //* Bone Minions
	{
		// Hero Power: Summon two 4/2 Bone Constructs.

		SimCard kid = CardIds.NonCollectible.Neutral.BoneConstructHeroic;//4/2Bone Construct
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
            p.callKid(kid, place, ownplay);
        }
	}
}