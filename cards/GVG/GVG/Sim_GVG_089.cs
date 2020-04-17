using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_089",
  "name": [
    "明光祭司",
    "Illuminator"
  ],
  "text": [
    "如果在你的回合结束时，你控制一个<b>奥秘</b>，则为你的英雄恢复#4点生命值。",
    "If you control a <b>Secret</b> at the end of your turn, restore #4 Health to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2057
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_089 : SimCard //Illuminator
    {

        //  if you control a Secret at the end of your turn, restore 4 health to your hero. 

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                if (((turnEndOfOwner) ? p.ownSecretsIDList.Count : p.enemySecretList.Count) >= 1)
                {
                    int heal = (turnEndOfOwner) ? p.getMinionHeal(4) : p.getEnemyMinionHeal(4);
                    p.minionGetDamageOrHeal(((turnEndOfOwner) ? p.ownHero : p.enemyHero), -heal, true);
                }
            }
        }

    }

}