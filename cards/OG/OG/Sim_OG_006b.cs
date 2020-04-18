using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_006b",
  "name": [
    "潮汐之力",
    "The Tidal Hand"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个1/1的白银之手鱼人。",
    "<b>Hero Power</b>\nSummon a 1/1 Silver Hand Murloc."
  ],
  "cardClass": "PALADIN",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "OG",
  "collectible": null,
  "dbfId": 39154
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_006b : SimTemplate //* The Tidal Hand
    {
        //Hero Power Summon a 1/1 Silver Hand Murloc.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Paladin.VilefinInquisitor_SilverHandMurloc;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
        }
    }
}