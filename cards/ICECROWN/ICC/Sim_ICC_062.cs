using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_062",
  "name": [
    "熔甲卫士",
    "Mountainfire Armor"
  ],
  "text": [
    "<b>亡语：</b>如果此时是你对手的回合，则获得\n6点护甲值。",
    "<b>Deathrattle:</b> If it's your opponent's turn,\ngain 6 Armor."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42698
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_062: SimTemplate //* Mountainfire Armor
    {
        // Deathrattle: If it's your opponent's turn, gain 6 Armor.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn) p.minionGetArmor(m.own ? p.ownHero : p.enemyHero, 6);
        }
    }
}