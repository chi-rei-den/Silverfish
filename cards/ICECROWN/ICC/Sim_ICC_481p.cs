using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_481p",
  "name": [
    "灵体转化",
    "Transmute Spirit"
  ],
  "text": [
    "<b>英雄技能</b>\n将一个友方随从随机变形成为一个法力值消耗增加（1）点的随从。",
    "<b>Hero Power:</b> Transform a friendly minion into a random one that costs (1) more."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 42982
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_481p: SimTemplate //* Transmute Spirit
    {
        // Hero Power: Transform a friendly minion into a random one that costs (1) more.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, p.getRandomCardForManaMinion(target.handcard.card.Cost + 1));
        }
    }
}