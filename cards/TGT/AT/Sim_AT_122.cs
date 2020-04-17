using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_122",
  "name": [
    "穿刺者戈莫克",
    "Gormok the Impaler"
  ],
  "text": [
    "<b>战吼：</b>如果你拥有至少四个其他随从，则造成4点伤害。",
    "<b>Battlecry:</b> If you have at least 4 other minions, deal 4 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2724
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_122 : SimCard //* Gormok the Impaler
	{
		//Battlecry: If you have at least 4 other minions, deal 4 damage.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetDamageOrHeal(target, 4);
        }
    }
}