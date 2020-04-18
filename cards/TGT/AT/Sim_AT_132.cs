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
            CardClass HeroStartClass = (m.own) ? p.ownHeroStartClass : p.enemyHeroStartClass;
			Chireiden.Silverfish.SimCard tmp = Chireiden.Silverfish.SimCard.None;

            switch (HeroStartClass)
            {
                case CardClass.WARRIOR:
					tmp = CardIds.NonCollectible.Warrior.JusticarTrueheart_TankUp; //Tank Up!
					break;
                case CardClass.WARLOCK:
					tmp = CardIds.NonCollectible.Warlock.JusticarTrueheart_SoulTap; //Soul Tap
                    break;
                case CardClass.ROGUE:
					tmp = CardIds.NonCollectible.Rogue.JusticarTrueheart_PoisonedDaggers; //Poisoned Daggers
					break;
                case CardClass.SHAMAN:
					tmp = CardIds.NonCollectible.Shaman.JusticarTrueheart_TotemicSlam; //Totemic Slam
					break;
                case CardClass.PRIEST:
					tmp = CardIds.NonCollectible.Priest.JusticarTrueheart_Heal; //Heal
					break;
                case CardClass.PALADIN:
					tmp = CardIds.NonCollectible.Paladin.JusticarTrueheart_TheSilverHand; //The Silver Hand
					break;
                case CardClass.MAGE:
					tmp = CardIds.NonCollectible.Mage.JusticarTrueheart_FireblastRank2; //Fireblast Rank 2
					break;
                case CardClass.HUNTER:
					tmp = CardIds.NonCollectible.Hunter.JusticarTrueheart_BallistaShot; //Ballista Shot
					break;
                case CardClass.DRUID:
					tmp = CardIds.NonCollectible.Druid.JusticarTrueheart_DireShapeshift; //Dire Shapeshift
                    break;
				//default:
			}

            if (tmp != Chireiden.Silverfish.SimCard.None) p.setNewHeroPower(tmp, m.own);
		}
	}
}