using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_090",
  "name": [
    "秘法宝典",
    "Cabalist's Tome"
  ],
  "text": [
    "随机将三张法师法术牌置入你的手牌。",
    "Add 3 random Mage spells to your hand."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 5,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38418
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_090 : SimTemplate //* Cabalist's Tome
	{
		//Add 3 random Mage spells to your hand.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Mage.Frostbolt, ownplay, true);
            p.drawACard(CardIds.Collectible.Mage.FrostNova, ownplay, true);
            p.drawACard(CardIds.Collectible.Mage.FrostNova, ownplay, true);
        }
    }
}