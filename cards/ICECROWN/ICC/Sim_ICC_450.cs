

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_450",
  "name": [
    "死亡幽魂",
    "Death Revenant"
  ],
  "text": [
    "<b>战吼：</b>每有一个受伤的随从，便获得+1/+1。",
    "<b>Battlecry:</b> Gain +1/+1 for each damaged minion."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42392
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_450 : SimTemplate //* Death Revenant
    {
        // Battlecry: Gain +1/+1 for each damaged minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var gain = 0;
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.wounded)
                {
                    gain++;
                }
            }

            if (gain >= 1)
            {
                p.minionGetBuffed(own, gain, gain);
            }
        }
    }
}