using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_094",
  "name": [
    "基维斯",
    "Jeeves"
  ],
  "text": [
    "在每个玩家的回合结束时，该玩家抽若干牌，直至其手牌数量达到3张。",
    "At the end of each player's turn, that player draws until they have 3 cards."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2062
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_094 : SimTemplate //Jeeves
    {

        //   At the end of each player's turn, that player draws until they have 3 cards.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {

            int cardstodraw = 0;
            if (p.owncards.Count <= 2)
            {
                cardstodraw = 3 - p.owncards.Count; 
            }

            for (int i = 0; i < cardstodraw; i++)
            {
                p.drawACard(CardDB.cardIDEnum.None, true);
            }
            cardstodraw = 0;

            //draw enemys cards...
            if (p.enemyAnzCards <= 2)
            {
                cardstodraw = 3 - p.enemyAnzCards;
            }

            for (int i = 0; i < cardstodraw; i++)
            {
                p.drawACard(CardDB.cardIDEnum.None, false);
            }

        }


    }

}