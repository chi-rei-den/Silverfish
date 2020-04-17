using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_058",
  "name": [
    "冷冻鱼人",
    "Brrrloc"
  ],
  "text": [
    "<b>战吼：</b>\n<b>冻结</b>一个敌人。",
    "<b>Battlecry:</b> <b>Freeze</b> an enemy."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42678
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_058: SimCard //* Brrrloc
    {
        // Battlecry: Freeze an enemy.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetFrozen(target);
        }
    }
}