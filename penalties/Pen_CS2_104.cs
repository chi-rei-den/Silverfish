using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_104 : PenTemplate //rampage
	{

//    verleiht einem verletzten diener +3/+3.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 50;
                }
                if (m.Hp == 1 && !m.divineshild)
                {
                    return 10;
                }
            }
            else
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.CardId == CardIds.Collectible.Neutral.BigGameHunter || hc.card.CardId == CardIds.Collectible.Priest.ShadowWordDeath) return 0;
                }

                return 500;
            }
            return 0;
		}

	}
}