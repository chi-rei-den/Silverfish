using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_080d",
  "name": [
    "石南草毒素",
    "Briarthorn Toxin"
  ],
  "text": [
    "使一个随从获得+3攻击力。",
    "Give a minion +3 Attack."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "OG",
  "collectible": null,
  "dbfId": 38940
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_080d : SimTemplate //* Briarthorn Toxin
	{
		//Give a minion +3 Attack.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 0);
        }
	}
}