using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX9_05H",
  "name": [
    "符文剑",
    "Runeblade"
  ],
  "text": [
    "如果其他天启骑士死亡，获得\n+6攻击力。",
    "Has +6 Attack if the other Horsemen are dead."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2126
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX9_05H : SimTemplate //* Runeblade
	{
		//Has +6 Attack if the other Horsemen are dead.
		//Handled in Horsemen
		SimCard weapon = CardIds.NonCollectible.Neutral.RunebladeHeroic;

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
			if (ownplay)
            {
				if (p.anzOwnHorsemen < 1)
				{
					p.ownWeapon.Angr += 6;
					p.minionGetBuffed(p.ownHero, 6, 0);
				}
            }
            else 
            {
				if (p.anzEnemyHorsemen < 1)
				{
					p.enemyWeapon.Angr += 6;
					p.minionGetBuffed(p.enemyHero, 6, 0);
				}
            }
		}
	}
}