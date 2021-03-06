using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_409t",
  "name": [
    "重斧",
    "Heavy Axe"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 1,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1661
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_409t : SimTemplate //* Heavy Axe
    {
        SimCard weapon = CardIds.NonCollectible.Warrior.Upgrade_HeavyAxeToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }
    }
}