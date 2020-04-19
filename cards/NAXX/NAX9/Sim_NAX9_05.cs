using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX9_05",
  "name": [
    "符文剑",
    "Runeblade"
  ],
  "text": [
    "如果其他天启骑士死亡，获得\n+3攻击力。",
    "Has +3 Attack if the other Horsemen are dead."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1882
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX9_05 : SimTemplate //* Runeblade
	{
		//Has +3 Attack if the other Horsemen are dead.
		//Handled in Horsemen
		Chireiden.Silverfish.SimCard weapon = CardIds.NonCollectible.Neutral.Runeblade;

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
			if (ownplay)
            {
				if (p.anzOwnHorsemen < 1)
				{
					p.ownWeapon.Angr += 3;
					p.minionGetBuffed(p.ownHero, 3, 0);
				}
            }
            else 
            {
				if (p.anzEnemyHorsemen < 1)
				{
					p.enemyWeapon.Angr += 3;
					p.minionGetBuffed(p.enemyHero, 3, 0);
				}
            }
		}
	}
}