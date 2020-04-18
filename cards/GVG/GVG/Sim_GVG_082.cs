using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_082",
  "name": [
    "发条侏儒",
    "Clockwork Gnome"
  ],
  "text": [
    "<b>亡语：</b>将一张<b>零件</b>牌置入你的手牌。",
    "<b>Deathrattle:</b> Add a <b>Spare Part</b> card to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2050
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_082 : SimTemplate //* Clockwork Gnome
    {

        //Deathrattle: Add a Spare Part card to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, m.own, true);
        }
    }
}