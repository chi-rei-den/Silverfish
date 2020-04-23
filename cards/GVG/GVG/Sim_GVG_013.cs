using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_013",
  "name": [
    "齿轮大师",
    "Cogmaster"
  ],
  "text": [
    "如果你控制任何机械，便获得\n+2攻击力。",
    "Has +2 Attack while you have a Mech."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1932
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_013 : SimTemplate //* Cogmaster
    {
        //    Has +2 Attack while you have a Mech.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (summonedMinion.handcard.card.Race == Race.MECHANICAL)
            {
                var temp = triggerEffectMinion.own ? p.ownMinions : p.enemyMinions;

                foreach (var m in temp)
                {
                    //if we have allready a mechanical, we are buffed
                    if (m.handcard.card.Race == Race.MECHANICAL)
                    {
                        return;
                    }
                }

                //we had no mechanical, but now!
                p.minionGetBuffed(triggerEffectMinion, 2, 0);
            }
        }

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            var diedMinions = m.own ? p.tempTrigger.ownMechanicDied : p.tempTrigger.enemyMechanicDied;
            if (diedMinions == 0)
            {
                return;
            }

            var residual = p.pID == m.pID ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            if (residual >= 1)
            {
                var temp = m.own ? p.ownMinions : p.enemyMinions;
                var hasmechanics = false;
                foreach (var mTmp in temp) //check if we have more mechanics, or debuff him
                {
                    if (mTmp.Hp >= 1 && mTmp.handcard.card.Race == Race.MECHANICAL)
                    {
                        hasmechanics = true;
                    }
                }

                if (!hasmechanics)
                {
                    p.minionGetBuffed(m, -2, 0);
                }
            }
        }
    }
}