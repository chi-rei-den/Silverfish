

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_007",
  "name": [
    "拉法姆的诅咒",
    "Curse of Rafaam"
  ],
  "text": [
    "使你的对手获得一张“诅咒”。在对手的回合开始时，如果它在对手的手牌中，则造成2点伤害。",
    "Give your opponent a 'Cursed!' card.\nWhile they hold it, they take 2 damage on their turn."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2879
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_007 : SimTemplate //* Curse of Rafaam
    {
        //Give your opponent a 'Cursed!' card. While they hold it, they take 2 damage on their turn.
        // handled in PenalityManager
    }
}