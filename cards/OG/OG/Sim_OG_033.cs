using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_033",
  "name": [
    "钢铁触须",
    "Tentacles for Arms"
  ],
  "text": [
    "<b>亡语：</b>将这把武器移回你的手牌。",
    "<b>Deathrattle:</b> Return this to your hand."
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38279
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_033 : SimTemplate //* Tentacles for Arms
    {
        //Deathrattle: Return this to your hand.

        SimCard weapon = CardIds.Collectible.Warrior.TentaclesForArms;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(p.ownWeapon.name, m.own, true);
        }
    }
}