using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_691",
  "name": [
    "青玉游荡者",
    "Jade Swarmer"
  ],
  "text": [
    "<b>潜行，亡语：</b>召唤一个{0}的<b>青玉魔像</b>。",
    "<b>Stealth</b>\n<b>Deathrattle:</b> Summon a{1} {0} <b>Jade Golem</b>."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40697
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_691 : SimTemplate //* Jade Swarmer
	{
		// Stealth, Deathrattle: Summon a Jade Golem.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(p.getNextJadeGolem(m.own), m.zonepos - 1, m.own);
        }
    }
}