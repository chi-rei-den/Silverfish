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
  "cardClass": "SHAMAN",
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

        Chireiden.Silverfish.SimCard searing = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_050);
        Chireiden.Silverfish.SimCard healing = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.NEW1_009);
        Chireiden.Silverfish.SimCard wrathofair = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_052);
        Chireiden.Silverfish.SimCard stoneclaw = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_051);

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
                    case Chireiden.Silverfish.SimCard.searingtotem: otherTotems++; continue;
                    case Chireiden.Silverfish.SimCard.stoneclawtotem: otherTotems++; continue;
                    case Chireiden.Silverfish.SimCard.healingtotem: otherTotems++; continue;
                    case Chireiden.Silverfish.SimCard.wrathofairtotem: wrath = true; continue;
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