using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_282",
  "name": [
    "克苏恩之刃",
    "Blade of C'Thun"
  ],
  "text": [
    "<b>战吼：</b>消灭一个随从。你的克苏恩会获得其攻击力和生命值<i>（无论它在哪里）。</i>",
    "<b>Battlecry:</b> Destroy a minion. Add its Attack and Health to your C'Thun's <i>(wherever it is).</i>"
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 9,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38861
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_282 : SimTemplate //* Blade of C'Thun
	{
		//Battlecry: Destroy a minion. Add its Attack and Health to C'Thun's (wherever it is).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if(target != null)
			{
                if (own.own) p.cthunGetBuffed(target.Angr, target.Hp, 0);
				p.minionGetDestroyed(target);
			}
		}
	}
}