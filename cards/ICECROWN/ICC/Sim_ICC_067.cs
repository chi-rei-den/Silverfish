using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_067",
  "name": [
    "维库食尸鬼",
    "Vryghoul"
  ],
  "text": [
    "<b>亡语：</b>如果此时是你对手的回合，则召唤一个2/2的食尸鬼。",
    "[x]<b>Deathrattle:</b> If it's your\nopponent's turn,\nsummon a 2/2 Ghoul."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42714
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_067: SimTemplate //* Vryghoul
    {
        // Deathrattle: If it's your opponent's turn, summon a 2/2 Ghoul.

        Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.ICC_900t); //Ghoul 2/2

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn) p.callKid(kid, m.zonepos, m.own);
        }
    }
}