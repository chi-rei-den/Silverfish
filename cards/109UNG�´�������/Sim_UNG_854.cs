using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_854 : SimTemplate //* Free From Amber
	{
		//Discover a minion that costs (8) or more. Summon it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (p.ownHeroHasDirectLethal()) p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_125), pos, ownplay, false);
            else p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_120), pos, ownplay, false);
        }
    }
}