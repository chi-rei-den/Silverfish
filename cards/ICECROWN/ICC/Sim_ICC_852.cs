using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_852",
  "name": [
    "塔达拉姆王子",
    "Prince Taldaram"
  ],
  "text": [
    "<b>战吼：</b>如果你的牌库里没有法力值消耗为（3）的牌，则该随从变形成为一个随从的3/3的复制。",
    "<b>Battlecry:</b> If your deck has no 3-Cost cards, transform into a 3/3 copy of a minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45341
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_852: SimTemplate //* Prince Taldaram
    {
        // Battlecry: If your deck has no 3-Cost cards, transform into a 3/3 copy of a minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.getDeckCardsForCost(3) == CardDB.cardIDEnum.None)
            {
                if (target != null)
                {
                    bool source = own.own;
                    own.setMinionToMinion(target);
                    own.own = source;
                    own.Angr = 3;
                    own.Hp = 3;
                    own.maxHp = 3;
                    own.handcard.card.sim_card.onAuraStarts(p, own);
                }
            }
        }
    }
}