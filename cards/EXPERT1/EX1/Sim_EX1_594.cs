using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_594",
  "name": [
    "蒸发",
    "Vaporize"
  ],
  "text": [
    "<b>奥秘：</b>当一个随从攻击你的英雄，将其消灭。",
    "<b>Secret:</b> When a minion attacks your hero, destroy it."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 286
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_594 : SimCard //vaporize
	{
        //todo secret
//    geheimnis:/ wenn ein diener euren helden angreift, wird er vernichtet.
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            p.minionGetDestroyed(target);
        }

	}

}