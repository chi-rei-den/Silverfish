using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_415",
  "name": [
    "缝合追踪者",
    "Stitched Tracker"
  ],
  "text": [
    "<b>战吼：</b>\n从你的牌库中<b>发现</b>一张随从牌的复制。",
    "<b>Battlecry:</b> <b>Discover</b> a copy of a minion in your deck."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42707
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_415 : SimTemplate //* Stitched Tracker
    {
        // Battlecry: Discover a copy of a minion in your deck.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(SimCard.None, own.own, true);
        }
    }
}