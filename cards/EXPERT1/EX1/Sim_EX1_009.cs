using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_009",
  "name": [
    "愤怒的小鸡",
    "Angry Chicken"
  ],
  "text": [
    "受伤时具有+5攻\n击力。",
    "Has +5 Attack while damaged."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1688
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_009 : SimCard //angrychicken
	{

//    wutanfall:/ +5 angriff.
        public override void onEnrageStart(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, 5, 0);
        }

        public override void  onEnrageStop(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, -5, 0);
        }

	}
}