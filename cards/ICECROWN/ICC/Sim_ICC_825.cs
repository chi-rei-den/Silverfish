using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_825",
  "name": [
    "憎恶弓箭手",
    "Abominable Bowman"
  ],
  "text": [
    "<b>亡语：</b>随机召唤一个在本局对战中死亡的友方野兽。",
    "[x]<b>Deathrattle:</b> Summon\na random friendly Beast\nthat died this game."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 7,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43245
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_825: SimTemplate //* Abominable Bowman
    {
        // Deathrattle: Summon a random friendly Beast that died this game.

        Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_172); //3/2 Bloodfen Raptor

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos - 1, m.own);
        }
    }
}