using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_754",
  "name": [
    "污手玩具商",
    "Grimy Gadgeteer"
  ],
  "text": [
    "在你的回合结束时，随机使你手牌中的一张随从牌获得+2/+2。",
    "At the end of your turn, give a random minion in your hand +2/+2."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40568
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_754 : SimTemplate //* Grimy Gadgeteer
	{
		// At the end of your turn, give a random minion in your hand +2/+2.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                if (triggerEffectMinion.own)
                {
                    Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.Mob);
                    if (hc != null)
                    {
                        hc.addattack += 2;
                        hc.addHp += 2;
                        p.anzOwnExtraAngrHp += 4;
                    }
                }
                else
                {
                    if (p.enemyAnzCards > 0) p.anzEnemyExtraAngrHp += 4;
                }
            }
        }
    }
}