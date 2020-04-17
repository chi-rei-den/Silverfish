using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX8_05t",
  "name": [
    "鬼灵骑兵",
    "Spectral Rider"
  ],
  "text": [
    "在你的回合开始时，对你的英雄造成\n1点伤害。",
    "At the start of your turn, deal 1 damage to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1878
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX8_05t : SimCard //* Spectral Rider
    {
        //    At the start of your turn, deal 1 damage to your hero.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
				p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, 1);
            }
        }

    }
}