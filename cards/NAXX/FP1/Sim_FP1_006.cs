

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_006",
  "name": [
    "死亡战马",
    "Deathcharger"
  ],
  "text": [
    "<b>冲锋，亡语：</b>对你的英雄造成3点伤害。",
    "<b>Charge. Deathrattle:</b> Deal 3 damage to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1785
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_006 : SimTemplate //deathcharger
    {
        //    ansturm. todesröcheln:/ fügt eurem helden 3 schaden zu.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.minionGetDamageOrHeal(m.own ? p.ownHero : p.enemyHero, 3);
        }
    }
}