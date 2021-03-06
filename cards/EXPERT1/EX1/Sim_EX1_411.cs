using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_411",
  "name": [
    "血吼",
    "Gorehowl"
  ],
  "text": [
    "攻击随从不会消耗耐久度，改为降低1点攻击力。",
    "Attacking a minion costs 1 Attack instead of 1 Durability."
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 7,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 810
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_411 : SimTemplate //Gorehowl
    {
        SimCard wcard = CardIds.Collectible.Warrior.Gorehowl;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.wcard, ownplay);
        }
    }
}