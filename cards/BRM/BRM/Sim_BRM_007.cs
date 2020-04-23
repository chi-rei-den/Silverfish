

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_007",
  "name": [
    "夜幕奇袭",
    "Gang Up"
  ],
  "text": [
    "选择一个随从。将该随从的三张复制洗入你的牌库。",
    "Choose a minion. Shuffle 3 copies of it into your deck."
  ],
  "CardClass": "ROGUE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2304
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_007 : SimTemplate //* Gang Up
    {
        // Choose a minion. Shuffle 3 copies of it into your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.ownDeckSize += 3;
            }
            else
            {
                p.enemyDeckSize += 3;
            }
        }
    }
}