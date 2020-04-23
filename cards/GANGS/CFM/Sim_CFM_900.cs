

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_900",
  "name": [
    "无证药剂师",
    "Unlicensed Apothecary"
  ],
  "text": [
    "在你召唤一个随从后，对你的英雄造成5点伤害。",
    "After you summon a minion, deal 5 damage to your hero."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40598
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_900 : SimTemplate //* Unlicensed Apothecary
    {
        // Whenever you summon a minion, deal 5 damage to your Hero.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own)
            {
                p.minionGetDamageOrHeal(triggerEffectMinion.own ? p.ownHero : p.enemyHero, 5);
            }
        }
    }
}