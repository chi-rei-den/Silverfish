using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_108",
  "name": [
    "大地之鳞",
    "Earthen Scales"
  ],
  "text": [
    "使一个友方随从获得+1/+1，然后获得等同于其攻击力的\n护甲值。",
    "Give a friendly minion +1/+1, then gain Armor equal to its Attack."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41081
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_108 : SimTemplate //* Earthen Scales
	{
		//Give a friendly minion +1/+1, then gain Armor equal to its Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 1, 1);
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, target.Angr);
        }
    }
}
