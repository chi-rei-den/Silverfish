using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_016",
  "name": [
    "顽石元素",
    "Rumbling Elemental"
  ],
  "text": [
    "在你使用一张具有\n<b>战吼</b>的随从牌后，随机对一个敌人造成2点伤害。",
    "After you play a <b>Battlecry</b> minion, deal 2 damage to a random enemy."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2888
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_016 : SimTemplate //* Rumbling Elemental
	{
		//After you play a Battlecry minion, deal 2 damage to a random enemy.
		
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (summonedMinion.handcard.card.Battlecry && summonedMinion.playedFromHand && summonedMinion.own == m.own && summonedMinion.entitiyID != m.entitiyID)
            {
                Minion target = null;

                if (m.own)
                {
                    target = p.getEnemyCharTargetForRandomSingleDamage(2);
                }
                else
                {
                    target = p.searchRandomMinion(p.ownMinions, SearchMode.searchHighestAttack); //damage the Highest (pessimistic)
                    if (target == null) target = p.ownHero;
                }
                p.minionGetDamageOrHeal(target, 2, true);
            }
        }
    }
}