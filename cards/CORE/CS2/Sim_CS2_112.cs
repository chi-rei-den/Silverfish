using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_112",
  "name": [
    "奥金斧",
    "Arcanite Reaper"
  ],
  "text": [
    null,
    null
  ],
  "CardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 304
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_112 : SimTemplate //arcanitereaper
    {
        SimCard card = CardIds.Collectible.Warrior.ArcaniteReaper;

        //
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.card, ownplay);
        }
    }
}