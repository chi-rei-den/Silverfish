using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_597",
  "name": [
    "小鬼召唤师",
    "Imp Master"
  ],
  "text": [
    "在你的回合结束时，对该随从造成1点伤害，并召唤一个1/1的\n小鬼。",
    "[x]At the end of your turn, deal\n1 damage to this minion\n and summon a 1/1 Imp."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 926
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_597 : SimTemplate //impmaster
	{

//    fügt am ende eures zuges diesem diener 1 schaden zu und beschwört einen wichtel (1/1).

        SimCard kid = CardIds.NonCollectible.Neutral.Imp;//imp

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int posi = triggerEffectMinion.zonepos;
                if (triggerEffectMinion.Hp == 1) posi--;
                p.minionGetDamageOrHeal(triggerEffectMinion, 1);
                p.callKid(kid, posi, triggerEffectMinion.own);
                triggerEffectMinion.stealth = false;
            }
        }

	}
}