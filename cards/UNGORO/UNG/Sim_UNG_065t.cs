using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_065t",
  "name": [
    "瑟拉金之种",
    "Sherazin, Seed"
  ],
  "text": [
    "<b>休眠</b>\n在一回合中使用四张牌可唤醒该随从。",
    "[x]<b>Dormant</b>\nWhen you play 4 cards\nin a turn, revive\nthis minion."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 11,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 42796
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_065t : SimTemplate //* Sherazin, Seed
	{
		//When you play 4 cards in a turn, revive this minion.

        Chireiden.Silverfish.SimCard kid = CardIds.Collectible.Rogue.SherazinCorpseFlower; //Sherazin, Corpse Flower

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            triggerEffectMinion.Angr++;
            triggerEffectMinion.cantAttack = true;
            if (triggerEffectMinion.Angr > 3) p.minionTransform(triggerEffectMinion, kid);
        }

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                triggerEffectMinion.Angr = 0;
            }
        }
    }
}