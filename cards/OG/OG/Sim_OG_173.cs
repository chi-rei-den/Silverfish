using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_173",
  "name": [
    "远古造物之血",
    "Blood of The Ancient One"
  ],
  "text": [
    "在你的回合结束时，如果你控制两个远古造物之血，则将其融合成远古造物。",
    "If you control two of these\nat the end of your turn, merge them into 'The Ancient One'."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38567
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_173 : SimTemplate //* Blood of The Ancient One
	{
		//If you control two of these at the end of your turn, merge them into 'The Ancient One'

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.BloodofTheAncientOne_TheAncientOne; //The Ancient One
		
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
				List<Minion> temp = (turnEndOfOwner) ? p.ownMinions : p.enemyMinions;
				int anz =0;
				foreach (Minion m in temp)
				{
                    if (m.name == CardIds.Collectible.Neutral.BloodOfTheAncientOne) anz++;
				}
				if (anz > 1)
				{
					anz = 0;
					foreach (Minion m in temp)
					{
                        if (m.name == CardIds.Collectible.Neutral.BloodOfTheAncientOne)
						{
							p.minionGetDestroyed(m);
							anz++;
							if (anz == 2) break;
						}
					}

					int pos = (triggerEffectMinion.own) ? p.ownMinions.Count : p.enemyMinions.Count;
					p.callKid(kid, pos, triggerEffectMinion.own, false, true); 
				}
            }
        }
	}
}