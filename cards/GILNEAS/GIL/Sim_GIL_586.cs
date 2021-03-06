using Chireiden.Silverfish;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GIL_586",
  "name": [
    "大地之力",
    "Earthen Might"
  ],
  "text": [
    "使一个随从获得+2/+2。如果该随从是元素，则随机将一张元素牌置入你的手牌。",
    "[x]Give a minion +2/+2.\nIf it's an Elemental, add\na random Elemental\nto your hand."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "GILNEAS",
  "collectible": true,
  "dbfId": 47152
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GIL_586 : SimTemplate //* 大地之力 Earthen Might
    {
//[x]Give a minion +2/+2.If it's an Elemental, adda random Elementalto your hand.
//使一个随从获得+2/+2。如果该随从是元素，则随机将一张元素牌置入你的手牌。
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 2);
            if (target.handcard.card.Race == Race.ELEMENTAL)
            {
                p.drawACard(SimCard.None, ownplay, true);
            }

            if (target.handcard.card.Race == Race.TOTEM)
            {
                p.evaluatePenality -= 5;
            }
        }
    }
}