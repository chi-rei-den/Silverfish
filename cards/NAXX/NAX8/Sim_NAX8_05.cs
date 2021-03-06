using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX8_05",
  "name": [
    "冷酷骑兵",
    "Unrelenting Rider"
  ],
  "text": [
    "<b>亡语：</b>为你的对手召唤一个鬼灵骑兵。",
    "<b>Deathrattle:</b> Summon a Spectral Rider for your opponent."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1877
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX8_05 : SimTemplate //* Unrelenting Rider
    {
//    Deathrattle:: Summon a Spectral Rider for your opponent.
        SimCard kid = CardIds.NonCollectible.Neutral.UnrelentingRider_SpectralRiderToken; //Spectral Rider

        public override void onDeathrattle(Playfield p, Minion m)
        {
            var place = m.own ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(this.kid, place, !m.own);
        }
    }
}