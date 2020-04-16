using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_715",
  "name": [
    "青玉之灵",
    "Jade Spirit"
  ],
  "text": [
    "<b>战吼：</b>召唤一个{0}的<b>青玉魔像</b>。",
    "<b>Battlecry:</b> Summon a{1} {0} <b>Jade Golem</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40527
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_715 : SimTemplate //* Jade Spirit
	{
		// Battlecry: Summon a Jade Golem.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(p.getNextJadeGolem(m.own), m.zonepos, m.own);
        }
	}
}