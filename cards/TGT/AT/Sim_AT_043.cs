using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_043",
  "name": [
    "星界沟通",
    "Astral Communion"
  ],
  "text": [
    "获得十个法力水晶。弃掉\n你的手牌。",
    "Gain 10 Mana Crystals. Discard your hand."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 4,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2785
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_043 : SimCard //* Astral Communion
	{
		//Gain 10 Mana Crystals. Discard your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.discardCards(10, ownplay);
            if (ownplay)
            {
				p.mana = 10;
				p.ownMaxMana = 10;
            }
            else
            {
				p.mana = 10;
				p.enemyMaxMana = 10;
            }
        }
    }
}