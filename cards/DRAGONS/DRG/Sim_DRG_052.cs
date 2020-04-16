using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "DRG_052",
  "name": [
    "龙族跟班",
    "Draconic Lackey"
  ],
  "text": [
    "<b>战吼：</b>\n<b>发现</b>一张龙牌。",
    "<b>Battlecry:</b> <b>Discover</b> a Dragon."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "DRAGONS",
  "collectible": null,
  "dbfId": 55378
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{

    public class Sim_DRG_052 : SimTemplate
    {


        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, own.own, true);
        }
    }
}