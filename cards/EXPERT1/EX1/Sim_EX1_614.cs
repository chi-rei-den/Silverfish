using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_614",
  "name": [
    "萨维斯",
    "Xavius"
  ],
  "text": [
    "在你使用一张牌后，召唤一个2/1的萨特。",
    "After you play a card, summon a 2/1 Satyr."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 556
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_614 : SimTemplate //illidanstormrage
	{
        SimCard d = CardIds.NonCollectible.Neutral.Xavius_XavianSatyrToken;//flameofazzinoth
//    beschwört jedes mal eine flamme von azzinoth (2/1), wenn ihr eine karte ausspielt.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own)
            {
                    p.callKid(d, triggerEffectMinion.zonepos, triggerEffectMinion.own);

            }
        }

	}
}