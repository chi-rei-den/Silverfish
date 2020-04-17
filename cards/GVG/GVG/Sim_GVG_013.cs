using System;
using System.Collections.Generic;
using System.Text;

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
    class Sim_GVG_013 : SimCard //* Cogmaster
    {

        //    Has +2 Attack while you have a Mech.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if ((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.MECHANICAL)
            {
                List<Minion> temp = (triggerEffectMinion.own) ? p.ownMinions : p.enemyMinions;

                foreach (Minion m in temp)
                {
                    //if we have allready a mechanical, we are buffed
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) return; 
                }

                //we had no mechanical, but now!
                p.minionGetBuffed(triggerEffectMinion, 2, 0);
            }
        }

		public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            int diedMinions = (m.own) ? p.tempTrigger.ownMechanicDied : p.tempTrigger.enemyMechanicDied;
            if (diedMinions == 0) return;
            int residual = (p.pID == m.pID) ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            if (residual >= 1)
			{
				List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
				bool hasmechanics = false;
                foreach (Minion mTmp in temp) //check if we have more mechanics, or debuff him
                {
                    if (mTmp.Hp >=1 && (TAG_RACE)mTmp.handcard.card.race == TAG_RACE.MECHANICAL) hasmechanics = true;
                }
				
                if (!hasmechanics)
                {
                    p.minionGetBuffed(m, -2, 0);
                }
            }
        }
    }
}