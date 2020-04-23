using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_ROGUEt",
  "name": [
    "浸毒匕首",
    "Poisoned Dagger"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "ROGUE",
  "type": "WEAPON",
  "cost": 1,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2746
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_132_ROGUEt : SimTemplate //* Poisoned Dagger
    {
        SimCard weapon = CardIds.NonCollectible.Rogue.JusticarTrueheart_PoisonedDagger;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }
    }
}