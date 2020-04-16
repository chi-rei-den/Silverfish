using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX4_04",
  "name": [
    "亡者复生",
    "Raise Dead"
  ],
  "text": [
    "<b>被动英雄技能</b>\n每当一个敌人死亡，召唤一个1/1的骷髅。",
    "<b>Passive Hero Power</b>\nWhenever an enemy dies, raise a 1/1 Skeleton."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1849
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX4_04 : SimTemplate //* Raise Dead
	{
		//Passive Hero Power: Whenever an enemy dies, raise a 1/1 Skeleton.
		//Handled in triggerAMinionDied()
	}
}