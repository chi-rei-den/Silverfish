using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_008",
  "name": [
    "黑铁潜藏者",
    "Dark Iron Skulker"
  ],
  "text": [
    "<b>战吼：</b>\n对所有未受伤的敌方随从造成2点伤害。",
    "<b>Battlecry:</b> Deal 2 damage to all undamaged enemy minions."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2291
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_008 : SimTemplate //* Dark Iron Skulker
	{
		//	Battlecry: Deal 2 damage to all undamaged enemy minions.
	
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			List<Minion> temp = (m.own) ? p.enemyMinions : p.ownMinions;
			
            foreach (Minion mnn in temp)
            {
                if (!mnn.wounded)
                {
					p.minionGetDamageOrHeal(mnn, 2);
                }
            }
        }
	}
}