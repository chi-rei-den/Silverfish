using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_849",
  "name": [
    "黑暗之拥",
    "Embrace Darkness"
  ],
  "text": [
    "选择一个敌方随从。在你的回合开始时，获得该随从的\n控制权。",
    "[x]Choose an enemy minion.\nAt the start of your turn,\ngain control of it."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 6,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45308
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_849: SimCard //* Embrace Darkness
    {
        // Choose an enemy minion. At the start of your turn, gain control of it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.changeOwnerOnTurnStart = true;
        }
    }
}