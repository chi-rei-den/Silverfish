

/* _BEGIN_TEMPLATE_
{
  "id": "ULD_239",
  "name": [
    "火焰结界",
    "Flame Ward"
  ],
  "text": [
    "<b>奥秘：</b>在一个随从攻击你的英雄后，对所有敌方随从造成$3点伤害。",
    "<b>Secret:</b> After a minion attacks your hero, deal $3 damage to all enemy minions."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ULDUM",
  "collectible": true,
  "dbfId": 53823
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ULD_239 : SimTemplate //* 火焰结界 Flame Ward
    {
        //<b>Secret:</b> After a minion attacks your hero, deal $3 damage to all enemy minions.
        //<b>奥秘：</b>在一个随从攻击你的英雄后，对所有敌方随从造成$3点伤害。
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
        }
    }
}