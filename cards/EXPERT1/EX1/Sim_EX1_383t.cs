using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_383t",
  "name": [
    "灰烬使者",
    "Ashbringer"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 5,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1730
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_383t : SimTemplate //ashbringer
    {
//
        SimCard wcard = CardIds.NonCollectible.Paladin.TirionFordring_AshbringerToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.wcard, ownplay);
        }
    }
}