using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_602a",
  "name": [
    "雕琢玉像",
    "Cut from Jade"
  ],
  "text": [
    "召唤一个{0}的<b>青玉魔像</b>。",
    "Summon a{1} {0} <b>Jade Golem</b>."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41409
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_602a : SimCard //* Jade Idol
	{
		// Summon a Jade Golem.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getNextJadeGolem(ownplay), pos, ownplay);
        }
    }
}