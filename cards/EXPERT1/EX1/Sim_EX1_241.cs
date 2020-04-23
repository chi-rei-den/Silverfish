

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_241",
  "name": [
    "熔岩爆裂",
    "Lava Burst"
  ],
  "text": [
    "造成$5点伤害，<b>过载：</b>（2）",
    "Deal $5 damage. <b>Overload:</b> (2)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 864
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_241 : SimTemplate //lavaburst
    {
//    verursacht $5 schaden. überladung:/ (2)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay)
            {
                p.ueberladung += 2;
            }
        }
    }
}