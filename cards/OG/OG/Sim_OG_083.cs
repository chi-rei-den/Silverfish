using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_083",
  "name": [
    "暮光烈焰召唤者",
    "Twilight Flamecaller"
  ],
  "text": [
    "<b>战吼：</b>对所有敌方随从造成1点伤害。",
    "<b>Battlecry:</b> Deal 1 damage to all enemy minions."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38409
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_083 : SimCard //* Twilight Flamecaller
	{
		//Battlecry: Deal 1 damage to all enemy minions
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			p.allMinionOfASideGetDamage(!own.own, 1);
        }
    }
}