using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_803",
  "name": [
    "翡翠掠夺者",
    "Emerald Reaver"
  ],
  "text": [
    "<b>战吼：</b>对每个英雄造成1点伤害。",
    "<b>Battlecry:</b> Deal 1 damage to each hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41309
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_803 : SimTemplate //* Emerald Reaver
	{
		//Battlecry: Deal 1 damage to each hero.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
				p.minionGetDamageOrHeal(p.enemyHero, 1);
				p.minionGetDamageOrHeal(p.ownHero, 1);
        }
    }
}