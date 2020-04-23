

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_117",
  "name": [
    "大地之环先知",
    "Earthen Ring Farseer"
  ],
  "text": [
    "<b>战吼：</b>\n恢复#3点生命值。",
    "<b>Battlecry:</b> Restore #3 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1651
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_117 : SimTemplate //earthenringfarseer
    {
//    kampfschrei:/ stellt 3 leben wieder her.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var heal = own.own ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
            p.minionGetDamageOrHeal(target, -heal);
        }
    }
}