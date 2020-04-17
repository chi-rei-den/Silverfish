using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_083",
  "name": [
    "龙鹰骑士",
    "Dragonhawk Rider"
  ],
  "text": [
    "<b>激励：</b>在本回合中，获得<b>风怒</b>。",
    "<b>Inspire:</b> Gain <b>Windfury</b>\nthis turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2533
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_083 : SimCard //* Dragonhawk Rider
	{
		//Inspire: Gain Windfury this turn.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				m.gotInspire = true;
				p.minionGetWindfurry(m);
			}
        }
		
		public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                if (triggerEffectMinion.gotInspire)
                {
                    triggerEffectMinion.windfury = false;
                    triggerEffectMinion.gotInspire = false;
                }
            }
        }
	}
}