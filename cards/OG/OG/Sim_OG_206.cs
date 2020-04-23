

/* _BEGIN_TEMPLATE_
{
  "id": "OG_206",
  "name": [
    "雷暴术",
    "Stormcrack"
  ],
  "text": [
    "对一个随从造成$4点伤害，<b>过载：</b>（1）",
    "Deal $4 damage to a minion. <b>Overload:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38724
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_206 : SimTemplate //* Stormcrack
    {
        //Deal 4 damage to a minion. Overload: (1)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay)
            {
                p.ueberladung++;
            }
        }
    }
}