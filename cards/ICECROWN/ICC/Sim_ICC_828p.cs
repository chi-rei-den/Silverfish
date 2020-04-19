using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_828p",
  "name": [
    "合成僵尸兽",
    "Build-A-Beast"
  ],
  "text": [
    "<b>英雄技能</b>\n制造一个自定义的僵尸兽。",
    "<b>Hero Power</b>\nCraft a custom Zombeast."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43183
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_828p: SimTemplate //* Build-a-Beast
    {
        // Hero Power: Craft a custom Zombeast.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay, true);
        }
    }
}