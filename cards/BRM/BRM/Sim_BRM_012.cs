using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_012",
  "name": [
    "火焰驱逐者",
    "Fireguard Destroyer"
  ],
  "text": [
    "<b>战吼：</b>获得1-4点攻击力。<b>过载：</b>（1）",
    "<b>Battlecry:</b> Gain 1-4 Attack. <b>Overload:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2290
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_012 : SimTemplate //* Fireguard Destroyer
    {
        // Battlecry: Gain 1-4 Attack. Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			if(m.own) p.minionGetBuffed(m, 2, 0);
            else p.minionGetBuffed(m, 3, 0);
            if (m.own) p.ueberladung++;
        }
    }
}