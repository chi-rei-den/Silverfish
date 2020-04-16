using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_029",
  "name": [
    "麻风侏儒",
    "Leper Gnome"
  ],
  "text": [
    "<b>亡语：</b>对敌方英雄造成2点伤害。",
    "<b>Deathrattle:</b> Deal 2 damage to the enemy hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 658
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_029 : SimTemplate //lepergnome
    {

        //    todesröcheln:/ fügt dem feindlichen helden 2 schaden zu.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, 2);
        }

    }
}