using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_107",
  "name": [
    "强化机器人",
    "Enhance-o Mechano"
  ],
  "text": [
    "<b>战吼：</b>随机使你的其他随从分别获得<b>风怒</b>，<b>嘲讽</b>，或者<b>圣盾</b>效果中的一种。",
    "<b>Battlecry:</b> Give your other minions <b>Windfury</b>, <b>Taunt</b>, or <b>Divine Shield</b>\n<i>(at random)</i>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2075
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_107 : SimCard //* Enhance-o Mechano
    {
        //  Battlecry: Give your other minions Windfury Taunt or Divine Shield

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if (!m.taunt)
                {
                    m.taunt = true;
                    if (m.own) p.anzOwnTaunt++;
                    else p.anzEnemyTaunt++;
                }
            }
        }
    }
}