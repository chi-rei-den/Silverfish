using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_250",
  "name": [
    "土元素",
    "Earth Elemental"
  ],
  "text": [
    "<b>嘲讽</b>，<b>过载：</b>（3）",
    "<b>Taunt</b>\n<b><b>Overload</b>:</b> (3)"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1141
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_250 : SimTemplate //earthelemental
	{

//    spott/, überladung:/ (3)
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.ueberladung += 3;
		}


	}
}