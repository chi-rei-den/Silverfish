using System;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_070",
  "name": [
    "虚灵商人",
    "Ethereal Peddler"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有其他职业的卡牌，则其法力值消耗减少（2）点。",
    "<b>Battlecry:</b> If you're holding any cards from another class, reduce their Cost by (2)."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39700
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_070 : SimTemplate //* Ethereal Peddler
    {
        //Battlecry: Reduce the Cost of cards in your hand from other classes by (2).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                var heroClass = p.ownHeroStartClass;
                foreach (var hc in p.owncards)
                {
                    if (hc.card.Class != heroClass && hc.card.Class != CardClass.INVALID)
                    {
                        hc.manacost = Math.Max(0, hc.manacost - 2);
                    }
                }
            }
        }
    }
}