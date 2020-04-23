

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_021",
  "name": [
    "末日预言者",
    "Doomsayer"
  ],
  "text": [
    "在你的回合开始时，消灭所有随从。",
    "At the start of your turn, destroy ALL minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 138
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_021 : SimTemplate //* Doomsayer
    {
        // At the start of your turn, destroy ALL minions.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                foreach (var m in p.ownMinions)
                {
                    if (m.entitiyID == triggerEffectMinion.entitiyID)
                    {
                        continue;
                    }

                    if (m.playedThisTurn || m.playedPrevTurn)
                    {
                        if (PenalityManager.Instance.ownSummonFromDeathrattle.ContainsKey(m.name))
                        {
                            continue;
                        }

                        p.evaluatePenality += (m.Hp * 2 + m.Angr * 2) * 2;
                    }
                }

                p.allMinionsGetDestroyed();
            }
        }
    }
}