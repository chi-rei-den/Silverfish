using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_092",
  "name": [
    "阿彻鲁斯老兵",
    "Acherus Veteran"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得+1攻击力。",
    "<b>Battlecry:</b> Give a friendly minion +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42773
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_092: SimTemplate //* Acherus Veteran
    {
        // Battlecry: Give a friendly minion +1 Attack.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 0);
        }
    }
}