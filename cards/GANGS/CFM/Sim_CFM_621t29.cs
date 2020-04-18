using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t29",
  "name": [
    "神秘羊毛",
    "Mystic Wool"
  ],
  "text": [
    "使所有随从变形成为1/1的绵羊。",
    "Transform all minions into 1/1 Sheep."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41625
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t29 : SimTemplate //* Mystic Wool
	{
		// Transform all minions into 1/1 Sheep.
		
		private CardIds.NonCollectible.Neutral.Sheep = CardIds.NonCollectible.Neutral.Kazakus_Sheep;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
				p.minionTransform(m, sheep);
            }
            foreach (Minion m in p.enemyMinions)
            {
				p.minionTransform(m, sheep);
            }
        }
    }
}