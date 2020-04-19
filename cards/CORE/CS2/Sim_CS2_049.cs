using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_049",
  "name": [
    "图腾召唤",
    "Totemic Call"
  ],
  "text": [
    "<b>英雄技能</b>\n随机召唤一个\n图腾。",
    "<b>Hero Power</b>\nSummon a random Totem."
  ],
  "CardClass": "SHAMAN",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 687
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_049 : SimTemplate // totemiccall
    {
        //Hero Power: Summon a random Totem.

        Chireiden.Silverfish.SimCard searing = CardIds.NonCollectible.Shaman.SearingTotem;
        Chireiden.Silverfish.SimCard healing = CardIds.NonCollectible.Shaman.HealingTotem;
        Chireiden.Silverfish.SimCard wrathofair = CardIds.NonCollectible.Shaman.WrathOfAirTotem;
        Chireiden.Silverfish.SimCard stoneclaw = CardIds.NonCollectible.Shaman.StoneclawTotem;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            Chireiden.Silverfish.SimCard kid;
            int otherTotems = 0;
            bool wrath = false;
            foreach (Minion m in (ownplay) ? p.ownMinions : p.enemyMinions)
            {
                switch (m.name)
                {
                    case CardIds.NonCollectible.Shaman.SearingTotem: otherTotems++; continue;
                    case CardIds.NonCollectible.Shaman.StoneclawTotem: otherTotems++; continue;
                    case CardIds.NonCollectible.Shaman.HealingTotem: otherTotems++; continue;
                    case CardIds.NonCollectible.Shaman.WrathOfAirTotem: wrath = true; continue;
                }
            }
            if (p.isLethalCheck)
            {
                if (otherTotems == 3 && !wrath) kid = wrathofair;
                else kid = healing;
            }
            else
            {
                if (!wrath) kid = wrathofair;
                else kid = searing;

                if (p.ownHeroHasDirectLethal()) kid = stoneclaw;
            }
            p.callKid(kid, pos, ownplay, false);
        }
    }

}