using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_081",
  "name": [
    "达卡莱防御者",
    "Drakkari Defender"
  ],
  "text": [
    "<b>嘲讽</b>，<b>过载：</b>（3）",
    "<b>Taunt</b>\n<b>Overload:</b> (3)"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42750
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_081: SimTemplate //* Drakkari Defender
    {
        // Taunt Overload: (3)

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ueberladung += 3;
        }
    }
}