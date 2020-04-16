using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_105",
  "name": [
    "探险帽",
    "Explorer's Hat"
  ],
  "text": [
    "使一个随从获得+1/+1，以及<b>亡语：</b>将一个探险帽置入你的手牌。",
    "Give a minion +1/+1 and \"<b>Deathrattle:</b> Add an Explorer's Hat to your hand.\""
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 3001
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_105 : SimTemplate //* Explorer's Hat
	{
		//Give a minion +1/+1 and "Deathrattle: Add an Explorer's Hat to your hand."

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 1, 1);
            target.explorershat++;
		}
	}
}