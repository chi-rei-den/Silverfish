

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_661",
  "name": [
    "缩小药水",
    "Pint-Size Potion"
  ],
  "text": [
    "在本回合中，使所有敌方随从获得-3攻击力。",
    "[x]Give all enemy minions\n-3 Attack this turn only."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40936
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_661 : SimTemplate //* Pint-Size Potion
    {
        // Give all enemy minions -3 Attack this turn only.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var temp = ownplay ? p.enemyMinions : p.ownMinions;
            foreach (var m in temp)
            {
                p.minionGetTempBuff(m, -3, 0);
            }
        }
    }
}