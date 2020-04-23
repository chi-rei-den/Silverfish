using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_089",
  "name": [
    "玛克扎尔的小鬼",
    "Malchezaar's Imp"
  ],
  "text": [
    "每当你弃掉一张牌时，抽一张牌。",
    "Whenever you discard a card, draw a card."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39740
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_089 : SimTemplate //* Malchezaar's Imp
    {
        //Whenever you discard a card, draw a card.

        public override bool onCardDicscard(Playfield p, Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (own == null)
            {
                return false;
            }

            if (checkBonus)
            {
                return false;
            }

            p.drawACard(SimCard.None, own.own);
            return false;
        }
    }
}