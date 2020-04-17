using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_073",
  "name": [
    "争强好胜",
    "Competitive Spirit"
  ],
  "text": [
    "<b>奥秘：</b>在你的回合开始时，使你的所有随从获得+1/+1。",
    "<b>Secret:</b> When your turn starts, give your minions +1/+1."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2648
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_073 : SimCard //* Competitive spirit
	{
		//Secret: When your turn starts, give your minions +1/+1.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            p.allMinionOfASideGetBuffed(ownplay, 1, 1);
        }
    }
}