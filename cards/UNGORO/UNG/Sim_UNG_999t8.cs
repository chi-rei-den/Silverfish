using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t8",
  "name": [
    "爆裂护盾",
    "Crackling Shield"
  ],
  "text": [
    "<b>圣盾</b>",
    "<b>Divine Shield</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41063
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_999t8 : SimTemplate //* Crackling Shield
	{
		//Divine Shield

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			target.divineshild = true;
        }
    }
}