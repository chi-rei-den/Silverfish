

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_916",
  "name": [
    "奔踏",
    "Stampede"
  ],
  "text": [
    "在本回合中，每当你使用一张野兽牌，随机将一张野兽牌置入你的手牌。",
    "Each time you play a Beast this turn, add a random Beast to your hand."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 1,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41360
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_916 : SimTemplate //* Stampede
    {
        //Each time you play a Beast this turn, add a random Beast to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.stampede++;
            }
        }
    }
}