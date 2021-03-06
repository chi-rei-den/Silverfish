using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX8_04",
  "name": [
    "冷酷战士",
    "Unrelenting Warrior"
  ],
  "text": [
    "<b>亡语：</b>为你的对手召唤一个鬼灵战士。",
    "<b>Deathrattle:</b> Summon a Spectral Warrior for your opponent."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1875
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX8_04 : SimTemplate //* Unrelenting Warrior
    {
//    Deathrattle:: Summon a Spectral Warrior for your opponent.
        SimCard kid = CardIds.NonCollectible.Neutral.UnrelentingWarrior_SpectralWarriorToken; //Spectral Warrior

        public override void onDeathrattle(Playfield p, Minion m)
        {
            var place = m.own ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(this.kid, place, !m.own);
        }
    }
}