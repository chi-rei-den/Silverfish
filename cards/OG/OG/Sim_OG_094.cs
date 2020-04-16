using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_094",
  "name": [
    "真言术：触",
    "Power Word: Tentacles"
  ],
  "text": [
    "使一个随从获得+2/+6。",
    "Give a minion +2/+6."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 5,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38426
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_094 : SimTemplate //* Power Word Tentacles
	{
		//Give a minion +2/+6.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 6);
        }
    }
}
