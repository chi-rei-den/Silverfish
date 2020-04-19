using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_829p",
  "name": [
    "天启四骑士",
    "The Four Horsemen"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个2/2的天启骑士。如果你控制所有四个天启骑士，消灭敌方英雄。",
    "[x]<b>Hero Power</b>\nSummon a 2/2 Horseman.\nIf you have all 4, destroy\nthe enemy hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43013
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_829p: SimTemplate //* The Four Horsemen
    {
        // Hero Power: Summon a 2/2 Horseman. If you have all 4, destroy the enemy hero.

        Chireiden.Silverfish.SimCard kid1 = CardIds.NonCollectible.Paladin.UtheroftheEbonBlade_DeathlordNazgrimToken; //Deathlord Nazgrim
        Chireiden.Silverfish.SimCard kid2 = CardIds.NonCollectible.Paladin.UtheroftheEbonBlade_ThorasTrollbaneToken; //Thoras Trollbane
        Chireiden.Silverfish.SimCard kid3 = CardIds.NonCollectible.Paladin.UtheroftheEbonBlade_InquisitorWhitemaneToken; //Inquisitor Whitemane
        Chireiden.Silverfish.SimCard kid4 = CardIds.NonCollectible.Paladin.UtheroftheEbonBlade_DarionMograineToken; //Darion Mograine

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid1, pos, ownplay, false);
        }
    }
}