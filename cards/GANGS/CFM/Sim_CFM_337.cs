using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_337",
  "name": [
    "食人鱼喷枪",
    "Piranha Launcher"
  ],
  "text": [
    "在你的英雄攻击后，召唤一个1/1的食人鱼。",
    "[x]After your hero attacks,\nsummon a 1/1 Piranha."
  ],
  "cardClass": "HUNTER",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40683
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_337 : SimTemplate //* Piranha Launcher
    {
        // Whenever your hero attacks, summon a 1/1 Piranha.

        SimCard weapon = CardIds.Collectible.Hunter.PiranhaLauncher;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }
    }
}