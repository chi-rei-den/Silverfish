using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_038",
  "name": [
    "先祖之魂",
    "Ancestral Spirit"
  ],
  "text": [
    "使一个随从获得“<b>亡语</b>：再次召唤该随从。”",
    "Give a minion \"<b>Deathrattle:</b> Resummon this minion.\""
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 404
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_038 : SimCard //ancestralspirit
	{

//    verleiht einem diener „todesröcheln:/ ruft diesen diener erneut herbei.“
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            target.ancestralspirit++;
		}

	}
}