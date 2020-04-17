using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_902",
  "name": [
    "艾雅·黑掌",
    "Aya Blackpaw"
  ],
  "text": [
    "<b>战吼，亡语：</b>召唤一个{0}的<b>青玉魔像</b>。",
    "<b>Battlecry and Deathrattle:</b> Summon a{1} {0} <b>Jade Golem</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40596
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_902 : SimCard //* Aya Blackpaw
	{
		// Battlecry and Deathrattle: Summon a Jade Golem.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(p.getNextJadeGolem(m.own), m.zonepos, m.own);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(p.getNextJadeGolem(m.own), m.zonepos - 1, m.own);
        }
    }
}