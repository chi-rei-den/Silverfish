

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_851",
  "name": [
    "“开拓者”伊莉斯",
    "Elise the Trailblazer"
  ],
  "text": [
    "<b>战吼：</b>\n将一张<b>安戈洛卡牌包</b>洗入你的牌库。",
    "<b>Battlecry:</b> Shuffle a sealed <b>Un'Goro</b> pack into your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41935
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_851 : SimTemplate //* Elise the Trailblazer
    {
        //Battlecry: Shuffle a sealed Un'Goro pack into your deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                p.ownDeckSize++;
            }
            else
            {
                p.enemyDeckSize++;
            }
        }
    }
}