using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_076",
  "name": [
    "鱼人骑士",
    "Murloc Knight"
  ],
  "text": [
    "<b>激励：</b>随机召唤一个鱼人。",
    "<b>Inspire:</b> Summon a random Murloc."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2655
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_076 : SimTemplate //* Murloc Knight
	{
		//Inspire: Summon a random Murloc.
		
		SimCard kid = CardIds.Collectible.Neutral.ColdlightOracle;//Coldlight Oracle 2/2

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.callKid(kid, m.zonepos, m.own);
			}
        }
	}
}