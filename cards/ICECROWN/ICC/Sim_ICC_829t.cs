using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_829t",
  "name": [
    "冰墓裁决",
    "Grave Vengeance"
  ],
  "text": [
    "<b>吸血</b>",
    "<b>Lifesteal</b>"
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 8,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43405
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_829t : SimTemplate //* 5/3 Grave Vengeance
    {
        //Lifesteal
        //Handled in minionAttacksMinion()

        SimCard weapon = CardIds.NonCollectible.Paladin.UtheroftheEbonBlade_GraveVengeanceToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }
    }
}