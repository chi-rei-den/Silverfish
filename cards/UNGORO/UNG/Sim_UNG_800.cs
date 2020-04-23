using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_800",
  "name": [
    "恐鳞追猎者",
    "Terrorscale Stalker"
  ],
  "text": [
    "<b>战吼：</b>触发一个友方随从的<b>亡语</b>。",
    "<b>Battlecry:</b> Trigger a friendly minion's <b>Deathrattle</b>."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41304
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_800 : SimTemplate //* Terrorscale Stalker
    {
        //Battlecry: Trigger a friendly minion's Deathrattle.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.doDeathrattles(new List<Minion> {target});
            }
        }
    }
}