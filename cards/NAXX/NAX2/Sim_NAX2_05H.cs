

/* _BEGIN_TEMPLATE_
{
  "id": "NAX2_05H",
  "name": [
    "膜拜者",
    "Worshipper"
  ],
  "text": [
    "你的英雄在你的回合获得+3攻击力。",
    "Your hero has +3 Attack on your turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2162
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX2_05H : SimTemplate //* Worshipper
    {
        // Your hero has +3 Attack on your turn.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            p.minionGetBuffed(own.own ? p.ownHero : p.enemyHero, 3, 0);
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            p.minionGetBuffed(own.own ? p.ownHero : p.enemyHero, -3, 0);
        }
    }
}