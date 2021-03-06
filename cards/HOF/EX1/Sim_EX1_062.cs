using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_062",
  "name": [
    "老瞎眼",
    "Old Murk-Eye"
  ],
  "text": [
    "<b>冲锋</b>，在战场上每有一个其他鱼人便获得+1攻击力。",
    "<b>Charge</b>. Has +1 Attack for each other Murloc on the battlefield."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "HOF",
  "collectible": true,
  "dbfId": 736
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_062 : SimTemplate //* oldmurkeye
    {
        // Charge. Has +1 Attack for each other Murloc on the battlefield.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            foreach (var m in p.ownMinions)
            {
                if (m.handcard.card.Race == Race.MURLOC)
                {
                    if (m.entitiyID != own.entitiyID)
                    {
                        p.minionGetBuffed(own, 1, 0);
                    }
                }
            }

            foreach (var m in p.enemyMinions)
            {
                if (m.handcard.card.Race == Race.MURLOC)
                {
                    if (m.entitiyID != own.entitiyID)
                    {
                        p.minionGetBuffed(own, 1, 0);
                    }
                }
            }
        }

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (summonedMinion.handcard.card.Race == Race.MURLOC)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            var diedMinions = p.tempTrigger.ownMurlocDied + p.tempTrigger.enemyMurlocDied;
            if (diedMinions == 0)
            {
                return;
            }

            var residual = p.pID == m.pID ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            if (residual >= 1)
            {
                p.minionGetBuffed(m, -1 * residual, 0);
            }
        }
    }
}