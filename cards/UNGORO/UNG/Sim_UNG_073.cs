using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_073",
  "name": [
    "石塘猎人",
    "Rockpool Hunter"
  ],
  "text": [
    "<b>战吼：</b>使一个友方鱼人获得+1/+1。",
    "<b>Battlecry:</b> Give a friendly Murloc +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41245
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_073 : SimTemplate //* Rockpool Hunter
	{
		//Battlecry: Give a friendly Murloc +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 1);
        }
    }
}