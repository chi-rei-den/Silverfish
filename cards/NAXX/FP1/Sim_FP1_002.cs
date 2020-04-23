using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_002",
  "name": [
    "鬼灵爬行者",
    "Haunted Creeper"
  ],
  "text": [
    "<b>亡语：</b>召唤两只1/1的鬼灵蜘蛛。",
    "<b>Deathrattle:</b> Summon two 1/1 Spectral Spiders."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1781
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_002 : SimTemplate //* hauntedcreeper
    {
        //Deathrattle: Summon two 1/1 Spectral Spiders.

        SimCard c = CardIds.NonCollectible.Neutral.HauntedCreeper_SpectralSpiderToken;

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(this.c, m.zonepos - 1, m.own);
            p.callKid(this.c, m.zonepos - 1, m.own);
        }
    }
}