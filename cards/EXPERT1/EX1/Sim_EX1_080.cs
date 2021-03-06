

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_080",
  "name": [
    "奥秘守护者",
    "Secretkeeper"
  ],
  "text": [
    "每当有一张<b>奥秘</b>牌被使用时，便获得+1/+1。",
    "Whenever a <b>Secret</b> is played, gain +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 158
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_080 : SimTemplate //* Secretkeeper
    {
        // Whenever a Secret: is played, gain +1/+1.

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool ownplay, Minion m)
        {
            if (hc.card.Secret)
            {
                p.minionGetBuffed(m, 1, 1);
            }
        }
    }
}