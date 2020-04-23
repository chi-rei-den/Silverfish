

/* _BEGIN_TEMPLATE_
{
  "id": "AT_055",
  "name": [
    "快速治疗",
    "Flash Heal"
  ],
  "text": [
    "恢复#5点生命值。",
    "Restore #5 Health."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2582
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_055 : SimTemplate //* Flash Heal
    {
        //Restore 5 Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var heal = ownplay ? p.getSpellHeal(5) : p.getEnemySpellHeal(5);
            p.minionGetDamageOrHeal(target, -heal);
        }
    }
}