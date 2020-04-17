using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_414",
  "name": [
    "格罗玛什·地狱咆哮",
    "Grommash Hellscream"
  ],
  "text": [
    "<b>冲锋</b>\n受伤时具有+6攻\n击力。",
    "<b>Charge</b>\nHas +6 Attack while damaged."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 338
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_414 : SimCard //grommashhellscream
	{

//    ansturm/, wutanfall:/ +6 angriff
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr+=6;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr-=6;
        }

	}
}