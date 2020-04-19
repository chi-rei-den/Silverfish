using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_003",
  "name": [
    "龙息术",
    "Dragon's Breath"
  ],
  "text": [
    "造成$4点伤害。在本回合中每有一个随从死亡，该牌的法力值消耗就减少（1）点。",
    "Deal $4 damage. Costs (1) less for each minion that died this turn."
  ],
  "CardClass": "MAGE",
  "type": "SPELL",
  "cost": 5,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2284
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_003 : SimTemplate //* Dragon's Breath
	{
		// Deal 4 damage. Costs (1) less for each minion that died this turn.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}