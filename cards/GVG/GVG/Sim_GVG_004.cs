using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_004",
  "name": [
    "地精炎术师",
    "Goblin Blastmage"
  ],
  "text": [
    "<b>战吼：</b>如果你控制任何机械，则造成4点伤害，随机分配到所有敌人身上。",
    "<b>Battlecry:</b> If you have a Mech, deal 4 damage randomly split among all enemies."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1934
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_004 : SimCard //* Goblin Blastmage
    {
        //Battlecry: If you have a Mech, deal 4 damage randomly split among all enemies.

        public override void  getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
				{
                    p.allCharsOfASideGetRandomDamage(!own.own, 4);
					break;
				}
            }
        }
    }
}