using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_087",
  "name": [
    "力量祝福",
    "Blessing of Might"
  ],
  "text": [
    "使一个随从获得+3攻击力。",
    "Give a minion +3 Attack."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 70
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_087 : SimCard//Blessing of Might
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 0);
        }

    }
}
