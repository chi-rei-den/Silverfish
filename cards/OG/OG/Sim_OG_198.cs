

/* _BEGIN_TEMPLATE_
{
  "id": "OG_198",
  "name": [
    "禁忌治疗",
    "Forbidden Healing"
  ],
  "text": [
    "消耗你所有的法力值，恢复等同于所消耗法力值数量两倍的生命值。",
    "Spend all your Mana. Restore twice that much Health."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 0,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38666
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_198 : SimTemplate //* Forbidden Healing
    {
        //Spend all your Mana. Heal for double the mana you spent.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetDamageOrHeal(target, -p.getSpellHeal(2 * p.mana));
                p.mana = 0;
            }
            else
            {
                p.minionGetDamageOrHeal(target, -p.getSpellHeal(2 * p.enemyMaxMana));
            }
        }
    }
}