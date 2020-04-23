

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_319",
  "name": [
    "烈焰小鬼",
    "Flame Imp"
  ],
  "text": [
    "<b>战吼：</b>对你的英雄造成3点伤害。",
    "<b>Battlecry:</b> Deal 3 damage to your hero."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1090
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_319 : SimTemplate //flameimp
    {
        //    kampfschrei:/ fügt eurem helden 3 schaden zu.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, 3);
        }
    }
}