

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_238",
  "name": [
    "闪电箭",
    "Lightning Bolt"
  ],
  "text": [
    "造成$3点伤害，<b>过载：</b>（1）",
    "Deal $3 damage. <b>Overload:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 505
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_238 : SimTemplate //lightningbolt
    {
//    verursacht $3 schaden. überladung:/ (1)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay)
            {
                p.ueberladung++;
            }
        }
    }
}