using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t2",
  "name": [
    "活性孢子",
    "Living Spores"
  ],
  "text": [
    "<b>亡语：</b>召唤两个1/1的植物。",
    "<b>Deathrattle:</b> Summon two 1/1 Plants."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41057
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_999t2 : SimCard //* Living Spores
	{
		//Deathrattle: Summon two 1/1 Plants.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.livingspores++;
        }
    }
}