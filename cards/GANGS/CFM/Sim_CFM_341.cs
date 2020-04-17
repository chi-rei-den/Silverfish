using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_341",
  "name": [
    "女警萨莉",
    "Sergeant Sally"
  ],
  "text": [
    "<b>亡语：</b>对所有敌方随从造成等同于该随从攻击力的伤害。",
    "<b>Deathrattle:</b> Deal damage equal to this minion's Attack to all enemy minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 41118
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_341 : SimCard //* Sergeant Sally
	{
		// Deathrattle: Deal damage equal to the minion's Attack to all enemy minions.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetDamage(!m.own, m.Angr);
        }
    }
}