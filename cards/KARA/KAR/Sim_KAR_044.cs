using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_044",
  "name": [
    "莫罗斯",
    "Moroes"
  ],
  "text": [
    "<b>潜行</b>\n在你的回合结束时，召唤一个1/1的\n家仆。",
    "<b>Stealth</b>\nAt the end of your turn, summon a 1/1 Steward."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39453
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_044 : SimTemplate //* Moroes
	{
		//Stealth. At the end of your turn, summon a 1/1 Steward.
		
        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.Moroes_Steward; //Steward

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int pos = triggerEffectMinion.zonepos;
                p.callKid(kid, pos, triggerEffectMinion.own);
            }
        }
	}
}