

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_604",
  "name": [
    "强效治疗药水",
    "Greater Healing Potion"
  ],
  "text": [
    "为一个友方角色恢复#12点\n生命值。",
    "Restore #12 Health to a friendly character."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40375
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_604 : SimTemplate //* Greater Healing Potion
    {
        // Restore 12 health to a friendly character.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var heal = ownplay ? p.getSpellHeal(12) : p.getEnemySpellHeal(12);
            p.minionGetDamageOrHeal(target, -heal);
        }
    }
}