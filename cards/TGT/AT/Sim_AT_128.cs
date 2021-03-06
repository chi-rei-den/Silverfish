

/* _BEGIN_TEMPLATE_
{
  "id": "AT_128",
  "name": [
    "骷髅骑士",
    "The Skeleton Knight"
  ],
  "text": [
    "<b>亡语：</b>揭示双方牌库里的一张随从牌。如果你的牌法力值消耗较大，则将骷髅骑士移回你的手牌。",
    "<b>Deathrattle:</b> Reveal a minion in each deck. If yours costs more, return this to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2681
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_128 : SimTemplate //* The Skeleton Knight
    {
        //Deathrattle: Reveal a minion in each deck. If yours costs more, return this to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.minionReturnToHand(m, m.own, 0); // optimistic		
        }
    }
}