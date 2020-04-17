using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_027",
  "name": [
    "审判",
    "Sacred Trial"
  ],
  "text": [
    "<b>奥秘：</b>在你的对手使用一张随从牌后，如果他控制至少三个随从，则将其消灭。",
    "<b>Secret:</b> After your opponent has at least 3 minions and plays another, destroy it."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2899
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_027 : SimCard //* Sacred Trial
	{
		//Secret: When your opponent has at least 3 minions and plays another, destroy it.

		public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            if (temp.Count > 3) p.minionGetDestroyed(target);
        }
    }
}