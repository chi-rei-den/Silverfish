using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_020",
  "name": [
    "缚链者拉兹",
    "Raza the Chained"
  ],
  "text": [
    "<b>战吼：</b>在本局对战中，如果你的牌库里没有相同的牌，则你的英雄技能的法力值消耗为（0）点。",
    "[x]  <b>Battlecry:</b> If your deck has  \nno duplicates, your Hero\n Power costs (0) this game."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40323
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_020 : SimCard //* Raza the Chained
	{
		// Battlecry: If your deck has no duplicates, your Hero Power costs (0) this game.
				
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.noDuplicates) p.ownHeroAblility.manacost = 0;
        }
	}
}