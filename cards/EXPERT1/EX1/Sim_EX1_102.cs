

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_102",
  "name": [
    "攻城车",
    "Demolisher"
  ],
  "text": [
    "在你的回合开始时，随机对一个敌人造成2点伤害。",
    "At the start of your turn, deal 2 damage to a random enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 979
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_102 : SimTemplate //demolisher
    {
        //    fügt zu beginn eures zuges einem zufälligen feind 2 schaden zu.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                var temp2 = turnStartOfOwner ? p.enemyMinions : p.ownMinions;
                var dmgdone = false;
                foreach (var mins in temp2)
                {
                    p.minionGetDamageOrHeal(mins, 2);
                    dmgdone = true;
                    break;
                }

                if (!dmgdone)
                {
                    p.minionGetDamageOrHeal(turnStartOfOwner ? p.enemyHero : p.ownHero, 2);
                }

                ;
            }
        }
    }
}