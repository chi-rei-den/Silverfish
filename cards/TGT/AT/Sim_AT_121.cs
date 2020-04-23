

/* _BEGIN_TEMPLATE_
{
  "id": "AT_121",
  "name": [
    "人气选手",
    "Crowd Favorite"
  ],
  "text": [
    "每当你使用一张具有<b>战吼</b>的牌，便获得+1/+1。",
    "Whenever you play a card with <b>Battlecry</b>, gain +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2518
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_121 : SimTemplate //* Crowd Favorite
    {
        //Whenever you play a card with Battlecry, gain +1/+1.

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.Battlecry)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }
    }
}