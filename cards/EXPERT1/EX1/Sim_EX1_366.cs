using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_366",
  "name": [
    "公正之剑",
    "Sword of Justice"
  ],
  "text": [
    "在你召唤一个随从后，使其获得+1/+1，这把武器失去1点耐久度。",
    "After you summon a minion, give it +1/+1 and this loses 1 Durability."
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 643
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_366 : SimTemplate //swordofjustice
	{
        Chireiden.Silverfish.SimCard card = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_366);

//    jedes mal, wenn ihr einen diener herbeiruft, erhält dieser +1/+1 und diese waffe verliert 1 haltbarkeit.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(card,ownplay);
		}

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own )
            {
                p.minionGetBuffed(summonedMinion, 1, 1);
                p.lowerWeaponDurability(1, triggerEffectMinion.own);
            }
        }
	}
}