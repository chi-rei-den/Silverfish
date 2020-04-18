using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA06_2H_TB",
  "name": [
    "火妖管理者",
    "The Majordomo"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个3/3的火妖卫士。",
    "<b>Hero Power</b>\nSummon a 3/3 Flamewaker Acolyte."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 36736
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA06_2H_TB : SimTemplate //* The Majordomo
	{
		// Hero Power: Summon a 3/3 Flamewaker Acolyte.
		
		Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.FlamewakerAcolyteHeroic;//3/3Flamewaker Acolyte
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
        }
	}
}