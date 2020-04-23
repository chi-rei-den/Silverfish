

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_049",
  "name": [
    "加兹瑞拉",
    "Gahz'rilla"
  ],
  "text": [
    "每当该随从受到伤害，便使其攻击力\n翻倍。",
    "Whenever this minion takes damage, double its Attack."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2017
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_049 : SimTemplate //* Gahz'rilla
    {
        // Whenever this minion takes damage, double its Attack.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                var tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                p.minionGetBuffed(m, m.Angr * (2 ^ tmp) - m.Angr, 0);
            }
        }
    }
}