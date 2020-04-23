using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_110t",
  "name": [
    "砰砰机器人",
    "Boom Bot"
  ],
  "text": [
    "<b>亡语：</b>随机对一个敌人造成1-4点伤害。",
    "<b>Deathrattle:</b> Deal 1-4 damage to a random enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2235
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_110t : SimTemplate //* Boom Bot
    {
        //  Deathrattle: Deal 1-4 damage to a random enemy.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            var temp = m.own ? p.enemyMinions : p.ownMinions;
            var target = p.searchRandomMinion(temp, SearchMode.HighHealth);
            if (target == null)
            {
                target = m.own ? p.enemyHero : p.ownHero;
            }

            p.minionGetDamageOrHeal(target, 2);
        }
    }
}