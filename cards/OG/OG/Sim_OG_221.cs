using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_221",
  "name": [
    "无私的英雄",
    "Selfless Hero"
  ],
  "text": [
    "<b>亡语：</b>随机使一个友方随从获得<b>圣盾</b>。",
    "<b>Deathrattle:</b> Give a random friendly minion <b>Divine Shield</b>."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38740
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_221 : SimTemplate //* Selfless Hero
	{
		//Deathrattle: Give a random friendly minion Divine Shield.

        public override void onDeathrattle(Playfield p, Minion m)
        {
			Minion target = (m.own) ? p.searchRandomMinion(p.ownMinions, SearchMode.LowAttack) : p.searchRandomMinion(p.enemyMinions, SearchMode.LowAttack);
			if (target != null) target.divineshild = true;
        }
    }
}