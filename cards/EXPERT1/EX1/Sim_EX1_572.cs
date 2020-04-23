using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_572",
  "name": [
    "伊瑟拉",
    "Ysera"
  ],
  "text": [
    "在你的回合结束时，将一张梦境牌置入你的手牌。",
    "At the end of your turn, add a Dream Card to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1186
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_572 : SimTemplate //ysera
    {
//    zieht am ende eures zuges eine traumkarte.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.drawACard(CardIds.NonCollectible.DreamCards.YseraAwakens, turnEndOfOwner, true);
            }
        }
    }
}