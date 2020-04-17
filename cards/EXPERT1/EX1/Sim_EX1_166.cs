using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_166",
  "name": [
    "丛林守护者",
    "Keeper of the Grove"
  ],
  "text": [
    "<b>抉择：</b>造成2点伤害；或者<b>沉默</b>一个随从。",
    "<b>Choose One -</b> Deal 2 damage; or <b>Silence</b> a minion."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 601
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_166 : SimCard //* Keeper of the Grove
	{
        // Choose One - Deal 2 damage; or Silence a minion.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.minionGetDamageOrHeal(target, 2);
            }

            if (choice == 2 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.minionGetSilenced(target);
            }
		}
	}
}