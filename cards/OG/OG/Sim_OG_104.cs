using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_104",
  "name": [
    "暗影之握",
    "Embrace the Shadow"
  ],
  "text": [
    "在本回合中，你的治疗效果转而造成等量的伤害。",
    "This turn, your healing effects deal damage instead."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38439
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_104 : SimCard //* Embrace the Shadow
    {
        //This turn, your healing effects deal damage instead.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{			
            if (ownplay)
            {
                p.embracetheshadow++;
            }
		}
	}
}