using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_031",
  "name": [
    "暮光神锤",
    "Hammer of Twilight"
  ],
  "text": [
    "<b>亡语：</b>召唤一个4/2的元素随从。",
    "<b>Deathrattle:</b> Summon a 4/2 Elemental."
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38270
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_031 : SimTemplate //* Hammer of Twilight
    {
        //Deathrattle: Summon a 4/2 Elemental.

        SimCard weapon = CardIds.Collectible.Shaman.HammerOfTwilight;
        SimCard kid = CardIds.Collectible.Shaman.HammerOfTwilighta;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, m.own);
        }
    }
}