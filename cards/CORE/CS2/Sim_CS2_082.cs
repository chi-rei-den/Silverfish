using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_082",
  "name": [
    "邪恶短刀",
    "Wicked Knife"
  ],
  "text": [
    null,
    null
  ],
  "CardClass": "ROGUE",
  "type": "WEAPON",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 485
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_082 : SimTemplate //* wickedknife
    {
        //-

        SimCard weapon = CardIds.NonCollectible.Rogue.WickedKnife;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }
    }
}