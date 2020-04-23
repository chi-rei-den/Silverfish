

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_100",
  "name": [
    "漂浮观察者",
    "Floating Watcher"
  ],
  "text": [
    "每当你的英雄在你的回合受到伤害，便获得+2/+2。",
    "Whenever your hero takes damage on your turn, gain +2/+2."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2068
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_100 : SimTemplate //* Floating Watcher
    {
        // Whenever your hero takes damage on your turn, gain +2/+2.  

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (p.ownHero.anzGotDmg > 0 && m.own)
            {
                p.minionGetBuffed(m, 2 * p.ownHero.anzGotDmg, 2 * p.ownHero.anzGotDmg);
            }
            else if (p.enemyHero.anzGotDmg > 0 && !m.own)
            {
                p.minionGetBuffed(m, 2 * p.enemyHero.anzGotDmg, 2 * p.enemyHero.anzGotDmg);
            }
        }
    }
}