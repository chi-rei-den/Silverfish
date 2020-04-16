using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_713",
  "name": [
    "青玉绽放",
    "Jade Blossom"
  ],
  "text": [
    "召唤一个{0}的<b>青玉魔像</b>，获得一个空的法力水晶。",
    "Summon a{1} {0} <b>Jade Golem</b>. Gain an empty Mana Crystal."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40523
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_713 : SimTemplate //* Jade Blossom
	{
		// Summon a Jade Golem. Gain an empty Mana Crystal.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getNextJadeGolem(ownplay), place, ownplay, false);

            if (ownplay) p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            else p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 1);
        }
    }
}