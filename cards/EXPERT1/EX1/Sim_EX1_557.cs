using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_557",
  "name": [
    "纳特·帕格",
    "Nat Pagle"
  ],
  "text": [
    "在你的回合开始时，你有50%的几率额外抽一张牌。",
    "At the start of your turn, you have a 50% chance to draw an extra card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1147
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_557 : SimTemplate //natpagle
    {
//    zu beginn eures zuges besteht eine chance von 50%, dass ihr eine zusätzliche karte zieht.
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.drawACard(SimCard.None, turnStartOfOwner);
            }
        }
    }
}