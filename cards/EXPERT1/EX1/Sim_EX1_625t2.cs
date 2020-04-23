

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_625t2",
  "name": [
    "心灵碎裂",
    "Mind Shatter"
  ],
  "text": [
    "<b>英雄技能</b>\n造成$3点伤害。",
    "<b>Hero Power</b>\nDeal $3 damage."
  ],
  "cardClass": "PRIEST",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1623
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_625t2 : SimTemplate //* Mind Shatter
    {
        //Hero Power: Deal 3 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}