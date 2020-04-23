

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_067",
  "name": [
    "猢狲医者",
    "Hozen Healer"
  ],
  "text": [
    "<b>战吼：</b>为一个随从恢复所有生命值。",
    "<b>Battlecry</b>: Restore a minion to full Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40344
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_067 : SimTemplate //* Hozen Healer
    {
        // Battlecry: Restore a minion to full Health.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                var heal = m.own ? p.getMinionHeal(target.maxHp - target.Hp) : p.getEnemyMinionHeal(target.maxHp - target.Hp);
                p.minionGetDamageOrHeal(target, -heal, true);
            }
        }
    }
}