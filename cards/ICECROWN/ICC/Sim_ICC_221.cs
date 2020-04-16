using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_221",
  "name": [
    "吸血药膏",
    "Leeching Poison"
  ],
  "text": [
    "在本回合中，你的武器获得\n<b>吸血</b>。",
    "Give your weapon <b>Lifesteal</b> this turn."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42665
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_221 : SimTemplate //* Leeching Poison
    {
        //Give your weapon Lifesteal.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.ownWeapon.lifesteal = true;
            else p.enemyWeapon.lifesteal = true;
        }
    }
}