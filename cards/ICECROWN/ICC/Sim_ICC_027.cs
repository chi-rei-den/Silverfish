using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_027",
  "name": [
    "白骨幼龙",
    "Bone Drake"
  ],
  "text": [
    "<b>亡语：</b>随机将一张龙牌置入你的手牌。",
    "<b>Deathrattle:</b> Add a random Dragon to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42439
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_027 : SimTemplate //* Bone Drake
    {
        // Deathrattle: Add a random Dragon to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIds.Collectible.Neutral.FaerieDragon, m.own, true);
        }
    }
}