using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_393",
  "name": [
    "阿曼尼狂战士",
    "Amani Berserker"
  ],
  "text": [
    "受伤时具有+3攻\n击力。",
    "Has +3 Attack while damaged."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 790
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_393 : SimTemplate //amaniberserker
	{

//    wutanfall:/ +3 angriff

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