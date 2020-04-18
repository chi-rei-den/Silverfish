using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_119",
  "name": [
    "布林顿3000型",
    "Blingtron 3000"
  ],
  "text": [
    "<b>战吼：</b>为每个玩家装备一把武器。",
    "<b>Battlecry:</b> Equip a random weapon for each player."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2087
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_119 : SimTemplate //Blingtron 3000
    {

        //   Battlecry: Equip a random weapon for each player.
        Chireiden.Silverfish.SimCard w = CardIds.Collectible.Rogue.AssassinsBlade;

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(w, true);
            p.equipWeapon(w, false);
        }


    }

}