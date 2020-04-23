

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_603",
  "name": [
    "严酷的监工",
    "Cruel Taskmaster"
  ],
  "text": [
    "<b>战吼：</b>对一个随从造成1点伤害，并使其获得+2攻击力。",
    "<b>Battlecry:</b> Deal 1 damage to a minion and give it +2 Attack."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 285
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_603 : SimTemplate //* Cruel Taskmaster
    {
        // Battlecry: Deal 1 damage to a minion and give it +2 

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDamageOrHeal(target, 1);
                p.minionGetBuffed(target, 2, 0);
            }
        }
    }
}