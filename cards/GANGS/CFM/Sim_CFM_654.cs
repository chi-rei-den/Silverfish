

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_654",
  "name": [
    "热心的酒保",
    "Friendly Bartender"
  ],
  "text": [
    "在你的回合结束时，为你的英雄恢复#1点生命值。",
    "At the end of your turn, restore #1 Health to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40914
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_654 : SimTemplate //* Friendly Bartender
    {
        // At the end of your turn, restore 1 Health to your Hero.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                if (triggerEffectMinion.own)
                {
                    var heal = p.getMinionHeal(1);
                    p.minionGetDamageOrHeal(p.ownHero, -heal, true);
                }
                else
                {
                    var heal = p.getEnemyMinionHeal(1);
                    p.minionGetDamageOrHeal(p.enemyHero, -heal, true);
                }
            }
        }
    }
}