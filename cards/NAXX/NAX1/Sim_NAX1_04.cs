using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX1_04",
  "name": [
    "飞掠召唤",
    "Skitter"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个3/1的\n蛛魔。",
    "<b>Hero Power</b>\nSummon a 3/1 Nerubian."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1831
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX1_04 : SimTemplate //* Skitter
	{
		// Hero Power: Summon a 3/1 Nerubian.
		
		SimCard kid = CardIds.NonCollectible.Neutral.Nerubian;//3/1Nerubian
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
        }
	}
}