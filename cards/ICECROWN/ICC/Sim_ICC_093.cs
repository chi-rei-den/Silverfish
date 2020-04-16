using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_093",
  "name": [
    "海象人渔夫",
    "Tuskarr Fisherman"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得<b>法术伤害+1</b>。",
    "<b>Battlecry:</b> Give a friendly minion <b>Spell Damage +1</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42775
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_093: SimTemplate //* Tuskarr Fisherman
    {
        // Battlecry: Give a friendly minion Spell Damage +1

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                target.spellpower++;
                if (target.own) p.spellpower++;
                else p.enemyspellpower++;
            }
        }
    }
}