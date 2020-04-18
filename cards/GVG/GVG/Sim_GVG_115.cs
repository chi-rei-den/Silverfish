using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_115",
  "name": [
    "托什雷",
    "Toshley"
  ],
  "text": [
    "<b>战吼，亡语：</b>\n将一张<b>零件</b>牌置入你的手牌。",
    "<b>Battlecry and Deathrattle:</b> Add a <b>Spare Part</b> card to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2083
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_115 : SimTemplate //Toshley
    {

        //   Battlecry Deathrattle: Add a Spare Part card to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIds.NonCollectible.Neutral.ArmorPlating, own.own, true);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIds.NonCollectible.Neutral.ArmorPlating, m.own, true);
        }


    }

}