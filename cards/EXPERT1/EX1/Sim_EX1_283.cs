using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_283",
  "name": [
    "冰霜元素",
    "Frost Elemental"
  ],
  "text": [
    "<b>战吼：</b>\n<b>冻结</b>一个角色。",
    "<b>Battlecry:</b> <b>Freeze</b> a character."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 512
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_283 : SimTemplate //* Frost Elemental
	{
        //Battlecry: Freeze a character.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetFrozen(target);
		}
	}
}