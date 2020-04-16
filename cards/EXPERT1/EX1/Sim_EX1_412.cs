using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_412",
  "name": [
    "暴怒的狼人",
    "Raging Worgen"
  ],
  "text": [
    "受伤时具有+1攻击力和<b>风怒</b>。",
    "Has +1 Attack and <b>Windfury</b> while damaged."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1155
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_412 : SimTemplate //ragingworgen
	{

//    wutanfall:/ windzorn/ und +1 angriff
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr++;
            p.minionGetWindfurry(m);
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr--;
            m.windfury = false;
            if (m.numAttacksThisTurn == 1) m.Ready = false;
        }


	}
}