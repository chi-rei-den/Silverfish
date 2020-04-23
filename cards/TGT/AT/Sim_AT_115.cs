

/* _BEGIN_TEMPLATE_
{
  "id": "AT_115",
  "name": [
    "击剑教头",
    "Fencing Coach"
  ],
  "text": [
    "<b>战吼：</b>你的下一个英雄技能的法力值消耗减少（2）点。",
    "<b>Battlecry:</b> The next time you use your Hero Power, it costs (2) less."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2581
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_115 : SimTemplate //* Fencing Coach
    {
        //Battlecry: The next time you use your Hero Power, it costs (2) less.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.ownHeroPowerCostLessOnce -= 2;
            }
            else
            {
                p.enemyHeroPowerCostLessOnce -= 2;
            }
        }
    }
}