using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_002 : SimTemplate //* Forgotten Torch
	{
		//Deal 3 damage. Shuffle a 'Roaring Torch' into your deck that deals 6 damage.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay)
			{
				p.ownDeckSize++;
				p.evaluatePenality -= 5;
			}
            else p.enemyDeckSize++;
		}
	}
}