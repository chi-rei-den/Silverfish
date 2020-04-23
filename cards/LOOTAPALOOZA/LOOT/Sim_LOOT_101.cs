


/* _BEGIN_TEMPLATE_
{
  "id": "LOOT_101",
  "name": [
    "爆炸符文",
    "Explosive Runes"
  ],
  "text": [
    "<b>奥秘：</b>在你的对手使用一张随从牌后，对该随从造成$6点伤害，超过其生命值的伤害将由对方英雄\n承受。",
    "<b>Secret:</b> After your opponent plays a minion, deal $6 damage to it and any excess to their hero."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "LOOTAPALOOZA",
  "collectible": true,
  "dbfId": 43407
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOOT_101 : SimTemplate //* 爆炸符文 Explosive Runes
    {
        //<b>Secret:</b> After your opponent plays a minion, deal $6 damage to it and any excess to their hero.
        //<b>奥秘：</b>在你的对手使用一张随从牌后，对该随从造成$6点伤害，超过其生命值上限的伤害将由对方英雄承受。
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);

            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}