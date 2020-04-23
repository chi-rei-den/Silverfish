using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_080",
  "name": [
    "毒心者夏克里尔",
    "Xaril, Poisoned Mind"
  ],
  "text": [
    "<b>战吼，亡语：</b>随机将一张毒素牌置入你的手牌。",
    "<b>Battlecry and Deathrattle:</b> Add a random Toxin card to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38403
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_080 : SimTemplate //* Xaril, Poisoned Mind
    {
        //Battlecry and Deathrattle: Add a random Toxin card to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIds.NonCollectible.Rogue.XarilPoisonedMind_BriarthornToxin, own.own, true);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIds.NonCollectible.Rogue.XarilPoisonedMind_FadeleafToxinEnchantment, m.own, true);
        }
    }
}