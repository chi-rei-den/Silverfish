using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_097",
  "name": [
    "真银圣剑",
    "Truesilver Champion"
  ],
  "text": [
    "每当你的英雄进攻，便为其恢复#2点生命值。",
    "Whenever your hero attacks, restore #2 Health to it."
  ],
  "CardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 847
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_097 : SimTemplate //truesilverchampion
    {
        SimCard card = CardIds.Collectible.Paladin.TruesilverChampion;

        //
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.card, ownplay);
        }
    }
}