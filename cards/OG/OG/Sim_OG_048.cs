using Chireiden.Silverfish;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_048",
  "name": [
    "亚煞极印记",
    "Mark of Y'Shaarj"
  ],
  "text": [
    "使一个随从获得+2/+2。\n如果该随从是野兽，抽一张牌。",
    "Give a minion +2/+2.\nIf it's a Beast, draw\na card."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38337
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_048 : SimTemplate //* Mark of Y'Shaarj
    {
        //Give a minion +2/+2. If it's a Beast, draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 2);
            if (target.handcard.card.Race == Race.BEAST)
            {
                p.drawACard(SimCard.None, ownplay);
            }
        }
    }
}