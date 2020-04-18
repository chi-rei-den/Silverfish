using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_061",
  "name": [
    "作战动员",
    "Muster for Battle"
  ],
  "text": [
    "召唤三个1/1的白银之手新兵，装备一把1/4的武器。",
    "Summon three 1/1 Silver Hand Recruits. Equip a 1/4 Weapon."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2029
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_061 : SimTemplate //* Muster for Battle
    {
        // Summon three 1/1 Silver Hand Recruits. Equip a 1/4 Weapon.

        Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_101t);
        Chireiden.Silverfish.SimCard w = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_091);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, pos, ownplay, false);
            for (int i = 0; i < 2; i++) p.callKid(kid, pos, ownplay);

            p.equipWeapon(w, ownplay);
        }
    }
}