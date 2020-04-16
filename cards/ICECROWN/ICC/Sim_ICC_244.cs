using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_244",
  "name": [
    "殊死一搏",
    "Desperate Stand"
  ],
  "text": [
    "使一个随从获得“<b>亡语：</b>回到战场，并具有1点生命值。”",
    "Give a minion \"<b>Deathrattle:</b> Return this to life with 1 Health.\""
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42824
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_244: SimTemplate //* Desperate Stand
    {
        // Give a minion: "Deathrattle: Revive this minion with one Health."

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.desperatestand++;
        }
    }
}