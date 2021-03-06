using HearthDb;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_028",
  "name": [
    "加里维克斯",
    "Trade Prince Gallywix"
  ],
  "text": [
    "每当你的对手施放一个法术，获得该法术的复制，并使其获得一个幸运币。",
    "Whenever your opponent casts a spell, gain a copy of it and give them a Coin."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1993
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_028 : SimTemplate //Trade Prince Gallywix
    {
        //    Whenever your opponent casts a spell, gain a copy of it and give them a Coin.

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            var c = hc.card;
            if (c.Type == CardType.SPELL && c.CardId != CardIds.NonCollectible.Neutral.TradePrinceGallywix_GallywixsCoinToken && wasOwnCard != triggerEffectMinion.own)
            {
                p.drawACard(c.CardId, triggerEffectMinion.own, true);
                p.drawACard(CardIds.NonCollectible.Neutral.TradePrinceGallywix_GallywixsCoinToken, wasOwnCard, true);
            }
        }
    }
}