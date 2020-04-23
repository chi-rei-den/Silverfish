

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_699",
  "name": [
    "海魔钉刺者",
    "Seadevil Stinger"
  ],
  "text": [
    "<b>战吼：</b>在本回合中，你召唤的下一个鱼人不再消耗法力值，转而消耗生命值。",
    "[x]<b>Battlecry:</b> The next Murloc\nyou play this turn costs\n Health instead of Mana."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40691
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_699 : SimTemplate //* Seadevil Stinger
    {
        // Battlecry: The next Murloc you play this turn costs Health instead of Mana.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                p.nextMurlocThisTurnCostHealth = true;
            }
        }
    }
}