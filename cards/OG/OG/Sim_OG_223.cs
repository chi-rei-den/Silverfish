using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_223",
  "name": [
    "神圣之力",
    "Divine Strength"
  ],
  "text": [
    "使一个随从获得+1/+2。",
    "Give a minion +1/+2."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38749
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_223 : SimTemplate //* Divine Strength
	{
		//Give a minion +1/+2.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 1, 2);
		}
	}
}