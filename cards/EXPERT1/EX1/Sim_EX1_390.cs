using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_390",
  "name": [
    "牛头人战士",
    "Tauren Warrior"
  ],
  "text": [
    "<b>嘲讽</b>\n受伤时具有+3攻\n击力。",
    "<b>Taunt</b>\nHas +3 Attack while damaged."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 45
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_390 : SimTemplate //taurenwarrior
	{

//    spott/, wutanfall:/ +3 angriff

        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr += 3;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr -= 3;
        }

	}
}