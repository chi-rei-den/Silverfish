using System;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_407",
  "name": [
    "侏儒吸血鬼",
    "Gnomeferatu"
  ],
  "text": [
    "<b>战吼：</b>移除你对手的牌库顶的一张牌。",
    "<b>Battlecry:</b> Remove\nthe top card of your opponent's deck."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42670
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_407 : SimTemplate //* Gnomeferatu
    {
        // Battlecry: Remove the top card of your opponent's deck.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.enemyDeckSize = Math.Max(0, p.enemyDeckSize - 1);
            }
            else
            {
                p.ownDeckSize = Math.Max(0, p.ownDeckSize - 1);
            }
        }
    }
}