using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_827p",
  "name": [
    "死亡暗影",
    "Death's Shadow"
  ],
  "text": [
    "<b>被动英雄技能</b>\n在你的回合时，将一张“暗影映像”置入你的手牌。",
    "<b>Passive Hero Power</b>\nDuring your turn, add a 'Shadow Reflection' to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43188
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_827p: SimTemplate //* Death's Shadow
    {
        // Passive Hero Power: During your turn, add a 'Shadow Reflection' to your hand.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            //!triggerEffectMinion = null
            bool found = false;
            if (turnStartOfOwner)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.CardId == Chireiden.Silverfish.SimCard.shadowreflection)
                    {
                        found = true;
                        break;
                    }
                }
            }
            if (!found) p.drawACard(Chireiden.Silverfish.SimCard.shadowreflection, turnStartOfOwner, true);
        }
    }
}