using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX4_04H",
  "name": [
    "亡者复生",
    "Raise Dead"
  ],
  "text": [
    "<b>被动英雄技能</b>\n每当一个敌人死亡，召唤一个5/5的骷髅。",
    "<b>Passive Hero Power</b>\nWhenever an enemy dies, raise a 5/5 Skeleton."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2115
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX4_04H : SimCard //* Raise Dead
	{
		//Passive Hero Power: Whenever an enemy dies, raise a 5/5 Skeleton.
		//Handled in triggerAMinionDied()
	}
}