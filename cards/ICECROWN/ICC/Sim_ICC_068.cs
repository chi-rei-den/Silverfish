using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_068",
  "name": [
    "寒冰行者",
    "Ice Walker"
  ],
  "text": [
    "你的英雄技能还会\n<b>冻结</b>目标。",
    "Your Hero Power also <b><b>Freeze</b>s</b> the target."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42716
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_068: SimTemplate //* Ice Walker
    {
        // Your Hero Power also Freezes the target.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.ownAbilityFreezesTarget++;
            else p.enemyAbilityFreezesTarget++;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.ownAbilityFreezesTarget--;
            else p.enemyAbilityFreezesTarget--;
        }
    }
}