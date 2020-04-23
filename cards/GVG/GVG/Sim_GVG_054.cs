using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_054",
  "name": [
    "食人魔战槌",
    "Ogre Warmaul"
  ],
  "text": [
    "50%几率攻击错误的敌人。",
    "50% chance to attack the wrong enemy."
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2022
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_054 : SimTemplate //Ogre Warmaul
    {
        //   50% chance to attack the wrong enemy.
        // yolo!?
        SimCard w = CardIds.Collectible.Warrior.OgreWarmaul;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.w, ownplay);
        }
    }
}