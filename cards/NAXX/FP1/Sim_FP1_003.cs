using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_003",
  "name": [
    "分裂软泥怪",
    "Echoing Ooze"
  ],
  "text": [
    "<b>战吼：</b>\n在回合结束时召唤一个该随从的复制。",
    "<b>Battlecry:</b> Summon an exact copy of this minion at the end of the turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1858
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_003 : SimCard //* Echoing Ooze
	{
        //Battlecry: Summon an exact copy of this minion at the end of the turn.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.playedThisTurn && triggerEffectMinion.own == turnEndOfOwner)
            {
                p.callKid(triggerEffectMinion.handcard.card, triggerEffectMinion.zonepos, turnEndOfOwner);
                List<Minion> temp = (turnEndOfOwner) ? p.ownMinions : p.enemyMinions;
                foreach (Minion mnn in temp)
                {
                    if (mnn.name == CardDB.cardName.echoingooze && triggerEffectMinion.entitiyID != mnn.entitiyID)
                    {
                        mnn.setMinionToMinion(triggerEffectMinion);
                        break;
                    }
                }
            }
        }

	}
}