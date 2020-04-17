using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_952",
  "name": [
    "剑龙骑术",
    "Spikeridged Steed"
  ],
  "text": [
    "使一个随从获得+2/+6和<b>嘲讽</b>。当该随从死亡时，召唤一个剑龙。",
    "Give a minion +2/+6 and <b>Taunt</b>. When it dies, summon a Stegodon."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41864
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_952 : SimCard //* Spikeridged Steed
	{
		//Give a minion +2/+6 and Taunt. When it dies, summon a Stegodon.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 2, 6);
			target.stegodon++;
		}
	}
}