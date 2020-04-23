

/* _BEGIN_TEMPLATE_
{
  "id": "NAX8_03t",
  "name": [
    "鬼灵学徒",
    "Spectral Trainee"
  ],
  "text": [
    "在你的回合开始时，对你的英雄造成\n1点伤害。",
    "At the start of your turn, deal 1 damage to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1874
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX8_03t : SimTemplate //* Spectral Trainee
    {
        //    At the start of your turn, deal 1 damage to your hero.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, 1);
            }
        }
    }
}