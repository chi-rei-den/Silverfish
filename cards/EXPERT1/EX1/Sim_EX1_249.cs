using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_249",
  "name": [
    "迦顿男爵",
    "Baron Geddon"
  ],
  "text": [
    "在你的回合结束时，对所有其他角色造成2点伤害。",
    "At the end of your turn, deal 2 damage to ALL other characters."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 336
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_249 : SimCard //* Baron Geddon
	{
        // At the end of your turn, deal 2 damage to ALL other characters.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                p.allCharsGetDamage(2, triggerEffectMinion.entitiyID);
            }
        }
	}
}