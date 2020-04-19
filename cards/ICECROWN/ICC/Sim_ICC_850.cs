using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_850",
  "name": [
    "暗影之刃",
    "Shadowblade"
  ],
  "text": [
    "<b>战吼：</b>在本回合中，你的英雄获得<b>免疫</b>。",
    "<b>Battlecry:</b> Your hero is <b>Immune</b> this turn."
  ],
  "cardClass": "ROGUE",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45338
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_850: SimTemplate //* Shadowblade
    {
        // Battlecry: Your hero is Immune this turn.

        Chireiden.Silverfish.SimCard weapon = CardIds.Collectible.Rogue.Shadowblade;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);

            if (ownplay) p.ownHero.immune = true;
            else p.enemyHero.immune = true;
        }
    }
}