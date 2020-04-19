using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_314t1",
  "name": [
    "霜之哀伤",
    "Frostmourne"
  ],
  "text": [
    "<b>亡语：</b>召唤被该武器消灭的所有\n随从。",
    "<b>Deathrattle:</b> Summon every minion killed by this weapon."
  ],
  "cardClass": "DEATHKNIGHT",
  "type": "WEAPON",
  "cost": 7,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43012
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_314t1 : SimTemplate //* Frostmourne
    {
        // Deathrattle: Summon every minion killed by this weapon.

        SimCard weapon = CardIds.NonCollectible.Deathknight.TheLichKing_FrostmourneToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(CardIds.NonCollectible.Neutral.CairneBloodhoof_BaineBloodhoofToken, m.zonepos - 1, m.own);//4/5 Baine Bloodhoof
        }
    }
}