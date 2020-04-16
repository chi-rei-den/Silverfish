using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_030",
  "name": [
    "电镀机械熊仔",
    "Anodized Robo Cub"
  ],
  "text": [
    "<b>嘲讽，抉择：</b>\n+1攻击力；或者+1生命值。",
    "<b>Taunt</b>. <b>Choose One -</b>\n+1 Attack; or +1 Health."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2096
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_030 : SimTemplate //* Anodized Robo Cub
    {
        // Taunt. Choose One - +1 Attack; or +1 Health.

           public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.minionGetBuffed(own, 1, 0);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.minionGetBuffed(own, 0, 1);
            }
		}
    }

}