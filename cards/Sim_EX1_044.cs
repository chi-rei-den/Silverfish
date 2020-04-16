using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_044 : SimTemplate //questingadventurer
	{

//    erhält jedes mal +1/+1, wenn ihr eine karte ausspielt.
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }
	}
}