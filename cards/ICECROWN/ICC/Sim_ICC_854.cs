using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_854",
  "name": [
    "阿尔福斯",
    "Arfus"
  ],
  "text": [
    "<b>亡语：</b>随机将一张<b>死亡骑士</b>牌置入你的\n手牌。",
    "<b>Deathrattle:</b> Add a random <b>Death Knight</b> card to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45366
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_854: SimCard //* Arfus
    {
        // Deathrattle: Add a random Death Knight card to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.None, m.own, true);
        }
    }
}