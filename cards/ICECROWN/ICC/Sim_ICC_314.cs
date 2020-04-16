using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_314",
  "name": [
    "巫妖王",
    "The Lich King"
  ],
  "text": [
    "<b>嘲讽</b>\n在你的回合结束时，随机将一张<b>死亡骑士</b>牌置入你的手牌。",
    "[x]<b>Taunt</b>\nAt the end of your turn,\nadd a random <b>Death Knight</b>\ncard to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42818
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_314 : SimTemplate //* The Lich King
    {
        // Taunt. At the end of your turn, add a random Death Knight card to your hand.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                if (triggerEffectMinion.own)
                {
                    p.drawACard(CardDB.cardIDEnum.None, triggerEffectMinion.own, true);
                }
                else
                {
                    if (p.enemyAnzCards < 10) p.enemyAnzCards++;
                }
            }
        }
    }
}