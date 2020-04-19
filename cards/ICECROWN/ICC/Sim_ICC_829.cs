using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_829",
  "name": [
    "黑锋骑士乌瑟尔",
    "Uther of the Ebon Blade"
  ],
  "text": [
    "<b>战吼：</b>\n装备一把5/3并具有<b>吸血</b>的武器。",
    "<b>Battlecry:</b> Equip a 5/3 <b>Lifesteal</b> weapon."
  ],
  "cardClass": "PALADIN",
  "type": "HERO",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43406
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_829: SimTemplate //* Uther of the Ebon Blade
    {
        // Battlecry: Equip a 5/3 Lifesteal weapon.

        SimCard w = CardIds.NonCollectible.Paladin.UtheroftheEbonBlade_GraveVengeanceToken; //Grave Vengeance

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Neutral.UtheroftheEbonBlade_TheFourHorsemen, ownplay); // The Four Horsemen
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            p.equipWeapon(w, ownplay);
        }
    }
}