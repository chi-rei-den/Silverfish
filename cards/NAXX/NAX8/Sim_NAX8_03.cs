using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX8_03",
  "name": [
    "冷酷学徒",
    "Unrelenting Trainee"
  ],
  "text": [
    "<b>亡语：</b>为你的对手召唤一个鬼灵学徒。",
    "<b>Deathrattle:</b> Summon a Spectral Trainee for your opponent."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1873
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX8_03 : SimTemplate //* Unrelenting Trainee
    {
//    Deathrattle:: Summon a Spectral Trainee for your opponent.
        SimCard kid = CardIds.NonCollectible.Neutral.UnrelentingTrainee_SpectralTraineeToken; //Spectral Trainee

        public override void onDeathrattle(Playfield p, Minion m)
        {
            var place = m.own ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(this.kid, place, !m.own);
        }
    }
}