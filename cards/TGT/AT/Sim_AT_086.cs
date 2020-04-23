

/* _BEGIN_TEMPLATE_
{
  "id": "AT_086",
  "name": [
    "破坏者",
    "Saboteur"
  ],
  "text": [
    "<b>战吼：</b>下个回合敌方英雄技能的法力值消耗增加（5）点。",
    "<b>Battlecry:</b> Your opponent's Hero Power costs (5) more next turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2576
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_086 : SimTemplate //* Saboteur
    {
        //Battlecry: Your opponent's Hero Power costs (5) more next turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.enemyHeroPowerCostLessOnce += 5;
            }
            else
            {
                p.ownHeroPowerCostLessOnce += 5;
            }
        }
    }
}