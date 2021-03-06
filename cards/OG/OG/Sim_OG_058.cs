using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_058",
  "name": [
    "锈蚀铁钩",
    "Rusty Hook"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 1,
  "rarity": null,
  "set": "OG",
  "collectible": null,
  "dbfId": 38363
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_058 : SimTemplate //* Rusty Hook
    {
        SimCard weapon = CardIds.NonCollectible.Warrior.RustyHook;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }
    }
}