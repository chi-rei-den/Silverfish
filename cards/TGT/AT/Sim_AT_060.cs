using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_060",
  "name": [
    "捕熊陷阱",
    "Bear Trap"
  ],
  "text": [
    "<b>奥秘：</b>在你的英雄受到攻击后，召唤一个3/3并具有<b>嘲讽</b>的灰熊。",
    "<b>Secret:</b> After your hero is attacked, summon a 3/3 Bear with <b>Taunt</b>."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2641
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_060 : SimTemplate //* Bear Trap
	{
		//Secret: After your hero is attacked, summon a 3/3 Bear with Taunt.

		Chireiden.Silverfish.SimCard kid = CardIds.Collectible.Neutral.IronfurGrizzly;//Ironfur Grizzly

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay);
        }
    }
}