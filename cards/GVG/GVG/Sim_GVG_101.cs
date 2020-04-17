using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_101",
  "name": [
    "血色净化者",
    "Scarlet Purifier"
  ],
  "text": [
    "<b>战吼：</b>\n对所有具有<b>亡语</b>的随从造成2点伤害。",
    "<b>Battlecry:</b> Deal 2 damage to all minions with <b>Deathrattle</b>."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2069
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_101 : SimCard //* Scarlet Purifier
    {
        //   Battlecry: Deal 2 damage to all minions with Deathrattle.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            foreach (Minion m in p.ownMinions)
            {
                if (m.handcard.card.deathrattle && !m.silenced) p.minionGetDamageOrHeal(m, 2);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.handcard.card.deathrattle && !m.silenced) p.minionGetDamageOrHeal(m, 2);
            }
        }
    }
}