using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t21",
  "name": [
    "神秘羊毛",
    "Mystic Wool"
  ],
  "text": [
    "随机使一个敌方随从变形成为1/1的绵羊。",
    "Transform a random enemy minion into a 1/1 Sheep."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41617
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t21 : SimTemplate //* Mystic Wool
	{
		// Transform a random enemy minion into a 1/1 Sheep.
		
		private CardIds.NonCollectible.Neutral.Sheep = CardIds.NonCollectible.Neutral.Kazakus_Sheep;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			target = (ownplay) ? p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestAttack) : p.searchRandomMinion(p.ownMinions, searchmode.searchLowestAttack);
			if (target != null) p.minionTransform(target, sheep);
        }
    }
}