using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_CS2_064 : PenTemplate //dreadinfernal
	{

//    kampfschrei:/ fügt allen anderen charakteren 1 schaden zu.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}