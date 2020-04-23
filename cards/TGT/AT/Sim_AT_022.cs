using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_022",
  "name": [
    "加拉克苏斯之拳",
    "Fist of Jaraxxus"
  ],
  "text": [
    "当你使用或弃掉这张牌时，随机对一个敌人造成$4点伤害。",
    "When you play or discard this, deal $4 damage to a random enemy."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2628
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_022 : SimTemplate //* Fist of Jaraxxus
    {
        //When you play or discard this, deal 4 damage to a random enemy.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            if (ownplay)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(dmg);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, SearchMode.LowHealth); //(pessimistic)
                if (target == null)
                {
                    target = p.ownHero;
                }
            }

            p.minionGetDamageOrHeal(target, dmg);
        }

        public override bool onCardDicscard(Playfield p, Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (checkBonus)
            {
                return true;
            }

            var ownplay = true;
            if (own != null)
            {
                ownplay = own.own;
            }

            Minion target = null;
            var dmg = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            if (ownplay)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(dmg);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, SearchMode.LowHealth); //(pessimistic)
                if (target == null)
                {
                    target = p.ownHero;
                }
            }

            p.minionGetDamageOrHeal(target, dmg);
            return true;
        }
    }
}