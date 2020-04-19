using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_100",
  "name": [
    "白银之手教官",
    "Silver Hand Regent"
  ],
  "text": [
    "<b>激励：</b>召唤一个1/1的白银之手新兵。",
    "<b>Inspire:</b> Summon a 1/1 Silver Hand Recruit."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2503
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_100 : SimTemplate //* Silver Hand Regent
	{
		//Inspire: Summon a 1/1 Silver Hand Recruit.
		
		SimCard kid = CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken;//silverhandrecruit
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own) p.callKid(kid, m.zonepos, own);
        }
	}
}