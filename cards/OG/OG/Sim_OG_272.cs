using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_272",
  "name": [
    "暮光召唤师",
    "Twilight Summoner"
  ],
  "text": [
    "<b>亡语：</b>召唤一个5/5的无面破坏者。",
    "<b>Deathrattle:</b> Summon a 5/5 Faceless Destroyer."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38833
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_272 : SimTemplate //* Twilight Summoner
    {
        //Deathrattle: Summon a 5/5 Faceless Destroyer.

        SimCard kid = CardIds.NonCollectible.Neutral.TwilightSummoner_FacelessDestroyerToken;

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(this.kid, m.zonepos - 1, m.own);
        }
    }
}