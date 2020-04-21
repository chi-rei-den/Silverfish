using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_047",
  "name": [
    "暗中破坏",
    "Sabotage"
  ],
  "text": [
    "随机消灭一个敌方随从，<b>连击：</b>并且摧毁你对手的武器。",
    "Destroy a random enemy minion. <b>Combo:</b> And your opponent's weapon."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 4,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2015
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_047 : SimTemplate //Sabotage
    {

        //   Destroy a random enemy minion. Combo: And your opponent's weapon.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay)? p.enemyMinions : p.ownMinions;
            if (temp.Count >= 1)
            {
                // Drew: Null check for searchRandomMinion.
                var found = p.searchRandomMinion(temp, SearchMode.LowHealth);
                if (found != null)
                {
                    p.minionGetDestroyed(found);
                }
            }
            if (p.cardsPlayedThisTurn >= 1) p.lowerWeaponDurability(1000, !ownplay);
        }


    }

}