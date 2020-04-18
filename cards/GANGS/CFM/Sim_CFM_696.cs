using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_696",
  "name": [
    "衰变",
    "Devolve"
  ],
  "text": [
    "随机将所有\n敌方随从变形成为法力值消耗减少（1）点的随从。",
    "Transform all enemy minions into random ones that cost (1) less."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40694
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_696 : SimTemplate //* Devolve
	{
		// Transform all enemy minions into random ones that cost (1) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            foreach (Minion m in temp)
            {
                p.minionTransform(m, p.getRandomCardForManaMinion(m.handcard.card.Cost - 1));
            }
        }
    }
}