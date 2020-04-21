using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_067",
  "name": [
    "碎石穴居人",
    "Stonesplinter Trogg"
  ],
  "text": [
    "每当你的对手施放一个法术，便获得+1攻击力。",
    "Whenever your opponent casts a spell, gain +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2035
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_067 : SimTemplate //Stonesplinter Trogg
    {

        //   Whenever your opponent casts a spell, gain +1 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.Type == CardType.SPELL && wasOwnCard != triggerEffectMinion.own)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }
    }

}