using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX6_04",
  "name": [
    "孢子爆发",
    "Sporeburst"
  ],
  "text": [
    "对所有敌方随从造成$1点伤害。召唤一个孢子。",
    "Deal $1 damage to all enemy minions. Summon a Spore."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2089
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX6_04 : SimTemplate //* Sporeburst
	{
		// Deal $1 damage to all enemy minions. Summon a Spore.
		
		Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.Deathbloom_SporeToken;//Spore

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
			
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay);
		}
	}
}