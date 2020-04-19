using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_068",
  "name": [
    "石腭穴居人壮汉",
    "Burly Rockjaw Trogg"
  ],
  "text": [
    "每当你的对手施放一个法术，获得\n+2攻击力。",
    "Whenever your opponent casts a spell, gain +2 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2036
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_068 : SimTemplate //Burly Rockjaw Trogg
    {

        //   Whenever your opponent casts a spell, gain +2 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.Type == CardType.SPELL && wasOwnCard != triggerEffectMinion.own)
            {
                p.minionGetBuffed(triggerEffectMinion, 2, 0);
            }
        }


    }

}