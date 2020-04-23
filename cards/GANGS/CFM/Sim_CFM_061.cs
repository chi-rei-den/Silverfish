

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_061",
  "name": [
    "锦鱼人水语者",
    "Jinyu Waterspeaker"
  ],
  "text": [
    "<b>战吼：</b>恢复#6点生命值。<b>过载：</b>（1）",
    "[x]<b>Battlecry:</b> Restore #6 Health.\n<b>Overload:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40285
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_061 : SimTemplate //* Jinyu Waterspeaker
    {
        // Battlecry: Restore 6 Health. Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            var heal = m.own ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);

            p.minionGetDamageOrHeal(target, -heal);
            if (m.own)
            {
                p.ueberladung++;
            }
        }
    }
}