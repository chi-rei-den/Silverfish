using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA06_2",
  "name": [
    "火妖管理者",
    "The Majordomo"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个1/3的火妖卫士。",
    "<b>Hero Power</b>\nSummon a 1/3 Flamewaker Acolyte."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2335
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA06_2 : SimTemplate //* The Majordomo
	{
		// Hero Power: Summon a 1/3 Flamewaker Acolyte.
		
		Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.FlamewakerAcolyte;//1/3Flamewaker Acolyte
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
        }
	}
}