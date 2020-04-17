using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_956",
  "name": [
    "灵魂回响",
    "Spirit Echo"
  ],
  "text": [
    "使你的所有随从获得“<b>亡语：</b>将该随从移回你的手牌”。",
    "Give your minions \"<b>Deathrattle:</b> Return  this to your hand.\""
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41879
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_956 : SimCard //* Spirit Echo
	{
		//Give your minions "Deathrattle: Return this to your hand."

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                m.returnToHand++;
            }
		}
	}
}