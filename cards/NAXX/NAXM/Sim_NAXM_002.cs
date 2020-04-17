using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAXM_002",
  "name": [
    "骷髅铁匠",
    "Skeletal Smith"
  ],
  "text": [
    "<b>亡语：</b>摧毁对手的武器。",
    "<b>Deathrattle:</b> Destroy your opponent's weapon."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1792
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAXM_002 : SimCard //* Skeletal Smith
	{
		// Deathrattle: Destroy your opponent's weapon.
		
		public override void onDeathrattle(Playfield p, Minion m)
		{
            p.lowerWeaponDurability(1000, !m.own);
		}
	}
}