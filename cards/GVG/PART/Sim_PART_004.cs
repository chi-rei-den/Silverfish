using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "PART_004",
  "name": [
    "隐秘力场",
    "Finicky Cloakfield"
  ],
  "text": [
    "直到你的下个回合，使一个友方随从获得<b>潜行</b>。",
    "Give a friendly minion <b>Stealth</b> until your next turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2154
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_PART_004 : SimTemplate //Finicky Cloakfield
    {

        //   Give a friendly minion Stealth until your next turn.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.stealth = true;
            target.conceal = true;
        }


    }

}