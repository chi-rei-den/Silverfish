using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "DS1_188",
  "name": [
    "角斗士的长弓",
    "Gladiator's Longbow"
  ],
  "text": [
    "你的英雄在攻击时具有<b>免疫</b>。",
    "Your hero is <b>Immune</b> while attacking."
  ],
  "cardClass": "HUNTER",
  "type": "WEAPON",
  "cost": 7,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 311
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DS1_188 : SimTemplate //gladiatorslongbow
    {
        SimCard c = CardIds.Collectible.Hunter.GladiatorsLongbow;

//    euer held ist immun/, während er angreift.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.c, ownplay);
        }
    }
}