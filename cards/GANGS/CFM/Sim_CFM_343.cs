using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_343",
  "name": [
    "青玉巨兽",
    "Jade Behemoth"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>召唤一个{0}的<b>青玉魔像</b>。",
    "[x]<b>Taunt</b>\n<b>Battlecry:</b> Summon a{1}\n{0} <b>Jade Golem</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40797
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_343 : SimTemplate //* Jade Behemoth
	{
		// Taunt. Battlecry: Summon a Jade Golem.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(p.getNextJadeGolem(m.own), m.zonepos, m.own);
        }
    }
}