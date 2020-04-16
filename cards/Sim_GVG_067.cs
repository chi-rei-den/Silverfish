using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_067 : SimTemplate //Stonesplinter Trogg
    {

        //   Whenever your opponent casts a spell, gain +1 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardDB.cardtype.SPELL && wasOwnCard != triggerEffectMinion.own)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }


    }

}