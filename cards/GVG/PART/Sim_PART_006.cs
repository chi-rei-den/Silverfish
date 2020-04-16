using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "PART_006",
  "name": [
    "形体改造仪",
    "Reversing Switch"
  ],
  "text": [
    "使一个随从的攻击力和生命值\n互换。",
    "Swap a minion's Attack and Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2156
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_PART_006 : SimTemplate //Reversing Switch
    {
        //   Swap a minion's Attack and Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSwapAngrAndHP(target);
        }
    }
}