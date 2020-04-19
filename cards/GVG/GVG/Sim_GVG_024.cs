using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_024",
  "name": [
    "齿轮大师的扳手",
    "Cogmaster's Wrench"
  ],
  "text": [
    "如果你控制任何机械，便获得\n+2攻击力。",
    "Has +2 Attack while you have a Mech."
  ],
  "cardClass": "ROGUE",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1989
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_024 : SimTemplate //* Cogmaster's Wrench
    {

        //    Has +2 Attack while you have a Mech.

        Chireiden.Silverfish.SimCard w = CardIds.Collectible.Rogue.CogmastersWrench;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);

            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((Race)m.handcard.card.Race == Race.MECHANICAL)
                {
                    if (ownplay)
                    {
                        p.ownWeapon.Angr += 2;
                        p.minionGetBuffed(p.ownHero, 2, 0);
                    }
                    else
                    {
                        p.enemyWeapon.Angr += 2;
                        p.minionGetBuffed(p.enemyHero, 2, 0);
                    }
                    break;
                }
            }
        }

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if ((Race)summonedMinion.handcard.card.Race == Race.MECHANICAL)
            {
                List<Minion> temp = (triggerEffectMinion.own) ? p.ownMinions : p.enemyMinions;

                foreach (Minion m in temp)
                {
                    if ((Race)m.handcard.card.Race == Race.MECHANICAL) return; 
                }

                if (triggerEffectMinion.own)
                {
                    p.ownWeapon.Angr += 2;
                    p.minionGetBuffed(p.ownHero, 2, 0);
                }
                else
                {
                    p.enemyWeapon.Angr += 2;
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                }
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
                foreach (Minion mTmp in temp)
                {
                    if (mTmp.Hp >=1 && (Race)mTmp.handcard.card.Race == Race.MECHANICAL) hasmechanics = true;
                }
				
                if (!hasmechanics)
                {
					if(m.own)
					{
						p.ownWeapon.Angr -= 2;
						p.minionGetBuffed(p.ownHero, -2, 0);
					}
					else
					{
                        p.enemyWeapon.Angr -= 2;
                        p.minionGetBuffed(p.enemyHero, -2, 0);
					}
                }
            }
        }
    }
}