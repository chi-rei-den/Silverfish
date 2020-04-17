using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_027",
  "name": [
    "威尔弗雷德·菲兹班",
    "Wilfred Fizzlebang"
  ],
  "text": [
    "你通过英雄技能抽到的卡牌，其法力值消耗为（0）点。",
    "Cards you draw from your Hero Power cost (0)."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2621
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_027 : SimCard //* Wilfred Fizzlebang
	{
		//Cards you draw from your Hero Power cost (0).
		//handled in PenalityManager
	}
}