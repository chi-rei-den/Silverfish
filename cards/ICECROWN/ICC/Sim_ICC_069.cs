using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_069",
  "name": [
    "鬼影巫师",
    "Ghastly Conjurer"
  ],
  "text": [
    "<b>战吼：</b>将一张“镜像”法术牌置入你的手牌。",
    "<b>Battlecry:</b> Add a 'Mirror Image' spell to your hand."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42718
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_069: SimTemplate //* Ghastly Conjurer
    {
        // Battlecry: Add a 'Mirror Image' spell to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.mirrorimage, own.own, true);
        }
    }
}