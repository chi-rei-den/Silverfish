using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_028",
  "name": [
    "愚者之灾",
    "Fool's Bane"
  ],
  "text": [
    "每个回合攻击次数不限，但无法攻击英雄。",
    "Unlimited attacks each turn. Can't attack heroes."
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39417
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_028 : SimTemplate //* Fool's Bane
    {
        //Unlimited attacks each turn. Can't attack heroes.
        // handled in public void getMoveList

        SimCard weapon = CardIds.Collectible.Warrior.FoolsBane;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }
    }
}