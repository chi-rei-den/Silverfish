using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132",
  "name": [
    "裁决者图哈特",
    "Justicar Trueheart"
  ],
  "text": [
    "<b>战吼：</b>以更强的英雄技能来替换你的初始英雄技能。",
    "<b>Battlecry:</b> Replace your starting Hero Power with a better one."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2736
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_132 : SimTemplate //* Justicar Trueheart
	{
		//Battlecry: Replace your starting Hero Power with a better one.
		
		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
		{
            TAG_CLASS HeroStartClass = (m.own) ? p.ownHeroStartClass : p.enemyHeroStartClass;
			Chireiden.Silverfish.SimCard tmp = Chireiden.Silverfish.SimCard.None;

            switch (HeroStartClass)
            {
                case TAG_CLASS.WARRIOR:
					tmp = Chireiden.Silverfish.SimCard.AT_132_WARRIOR; //Tank Up!
					break;
                case TAG_CLASS.WARLOCK:
					tmp = Chireiden.Silverfish.SimCard.AT_132_WARLOCK; //Soul Tap
                    break;
                case TAG_CLASS.ROGUE:
					tmp = Chireiden.Silverfish.SimCard.AT_132_ROGUE; //Poisoned Daggers
					break;
                case TAG_CLASS.SHAMAN:
					tmp = Chireiden.Silverfish.SimCard.AT_132_SHAMAN; //Totemic Slam
					break;
                case TAG_CLASS.PRIEST:
					tmp = Chireiden.Silverfish.SimCard.AT_132_PRIEST; //Heal
					break;
                case TAG_CLASS.PALADIN:
					tmp = Chireiden.Silverfish.SimCard.AT_132_PALADIN; //The Silver Hand
					break;
                case TAG_CLASS.MAGE:
					tmp = Chireiden.Silverfish.SimCard.AT_132_MAGE; //Fireblast Rank 2
					break;
                case TAG_CLASS.HUNTER:
					tmp = Chireiden.Silverfish.SimCard.AT_132_HUNTER; //Ballista Shot
					break;
                case TAG_CLASS.DRUID:
					tmp = Chireiden.Silverfish.SimCard.AT_132_DRUID; //Dire Shapeshift
                    break;
				//default:
			}

            if (tmp != Chireiden.Silverfish.SimCard.None) p.setNewHeroPower(tmp, m.own);
		}
	}
}