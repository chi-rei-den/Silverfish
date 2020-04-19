using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_292",
  "name": [
    "狼人追猎者",
    "Forlorn Stalker"
  ],
  "text": [
    "<b>战吼：</b>使你手牌中所有<b>亡语</b>随从牌获得+1/+1。",
    "<b>Battlecry:</b> Give all <b>Deathrattle</b> minions in your hand +1/+1."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38875
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_292 : SimTemplate //* Forlorn Stalker
    {
        //Battlecry: Give all minions with Deathrattle in your hand +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.Deathrattle)
                    {
                        hc.addattack++;
                        hc.addHp++;
                    }
                }
            }
        }
    }
}