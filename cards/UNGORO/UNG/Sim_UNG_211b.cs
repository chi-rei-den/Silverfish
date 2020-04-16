using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_211b",
  "name": [
    "水之祈咒",
    "Invocation of Water"
  ],
  "text": [
    "为你的英雄恢复12点生命值。",
    "Restore 12 Health to your hero."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41334
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_211b : SimTemplate //* Invocation of Water
	{
		//Restore 12 Health to your hero.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(12) : p.getEnemySpellHeal(12);
			p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
		}
	}
}