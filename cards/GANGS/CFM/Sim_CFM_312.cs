using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_312",
  "name": [
    "青玉酋长",
    "Jade Chieftain"
  ],
  "text": [
    "<b>战吼：</b>召唤一个{0}的<b>青玉魔像</b>，使其获得<b>嘲讽</b>。",
    "<b>Battlecry:</b> Summon a{1} {0} <b>Jade Golem</b>. Give it <b>Taunt</b>."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 7,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40422
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_312 : SimTemplate //* Jade Chieftain
	{
		// Battlecry: Summon a Jade Golem. Give it Taunt.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(p.getNextJadeGolem(m.own), m.zonepos, m.own);
            Minion mnn = m.own ? p.ownMinions[m.zonepos] : p.enemyMinions[m.zonepos];
            if (mnn.playedThisTurn && !mnn.taunt)
            {
                mnn.taunt = true;
                if (mnn.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}