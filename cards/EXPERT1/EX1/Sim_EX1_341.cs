

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_341",
  "name": [
    "光明之泉",
    "Lightwell"
  ],
  "text": [
    "在你的回合开始时，随机为一个受伤的\n友方角色恢复#3点生命值。",
    "At the start of your turn, restore #3 Health to a damaged friendly character."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 797
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_341 : SimTemplate //lightwell
    {
        // <deDE>Stellt zu Beginn Eures Zuges bei einem verletzten befreundeten Charakter 3 Leben wieder her.</deDE>
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                var heal = turnStartOfOwner ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
                var temp = turnStartOfOwner ? p.ownMinions : p.enemyMinions;
                if (temp.Count >= 1)
                {
                    var healed = false;
                    foreach (var mins in temp)
                    {
                        if (mins.wounded)
                        {
                            p.minionGetDamageOrHeal(mins, -heal);
                            healed = true;
                            break;
                        }
                    }

                    if (!healed)
                    {
                        p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, -heal);
                    }
                }
                else
                {
                    p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, -heal);
                }
            }
        }
    }
}