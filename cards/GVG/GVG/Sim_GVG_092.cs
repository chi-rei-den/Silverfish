using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_092",
  "name": [
    "侏儒实验技师",
    "Gnomish Experimenter"
  ],
  "text": [
    "<b>战吼：</b>\n抽一张牌，如果该牌是随从牌，则将其变形成为一只小鸡。",
    "<b>Battlecry:</b> Draw a card. If it's a minion, transform it into a Chicken."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2060
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_092 : SimTemplate //Gnomish Experimenter
    {

        //  Battlecry: Draw a card. If it's a minion, transform it into a Chicken. 

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, own.own);
        }

    }

}