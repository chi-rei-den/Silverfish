using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_121",
  "name": [
    "古加尔",
    "Cho'gall"
  ],
  "text": [
    "<b>战吼：</b>在本回合中，你施放的下一个法术不再消耗法力值，转而消耗生命值。",
    "<b>Battlecry:</b> The next spell you cast this turn costs Health instead of Mana."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38464
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_121 : SimTemplate //* Cho'Gall
    {
        //Battlecry: The next spell you cast this turn costs Health instead of Mana.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own) p.nextSpellThisTurnCostHealth = true;
        }
    }
}