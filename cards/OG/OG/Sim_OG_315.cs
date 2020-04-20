using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_315",
  "name": [
    "血帆教徒",
    "Bloodsail Cultist"
  ],
  "text": [
    "<b>战吼：</b>如果你控制其他任何海盗，你的武器便获得+1/+1。",
    "<b>Battlecry:</b> If you control another Pirate, give your weapon +1/+1."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38920
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_315 : SimTemplate //* Bloodsail Cultist
    {
        //Battlecry: If you control a Pirate, give your weapon +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if (m.handcard.card.Race == Race.PIRATE)
                {
                    if (own.own)
                    {
                        if (p.ownWeapon.Durability > 0)
                        {
                            p.ownWeapon.Durability++;
                            p.ownWeapon.Angr++;
                            p.minionGetBuffed(p.ownHero, 1, 0);
                        }
                    }
                    else
                    {
                        if (p.enemyWeapon.Durability > 0)
                        {
                            p.enemyWeapon.Durability++;
                            p.enemyWeapon.Angr++;
                            p.minionGetBuffed(p.enemyHero, 1, 0);
                        }
                    }
                    break;
                }
            }
        }
    }
}