

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_625t",
  "name": [
    "心灵尖刺",
    "Mind Spike"
  ],
  "text": [
    "<b>英雄技能</b>\n造成$2点伤害。",
    "<b>Hero Power</b>\nDeal $2 damage."
  ],
  "cardClass": "PRIEST",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1622
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_625t : SimTemplate //* Mind Spike
    {
        //Hero Power: Deal 2 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}