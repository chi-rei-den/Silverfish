using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_134",
  "name": [
    "尤格-萨隆",
    "Yogg-Saron, Hope's End"
  ],
  "text": [
    "<b>战吼：</b>\n在本局对战中，你每施放过一个法术，便随机施放一个法术<i>（目标随机而定）</i>。",
    "<b>Battlecry:</b> Cast a random spell for each spell you've cast this game <i>(targets chosen randomly)</i>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38505
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_134 : SimTemplate //* Yogg-Saron, Hope's End
    {
        //Battlecry: Cast a random spell for each spell you've cast this game (targets chosen randomly).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.ownMinions.Count < p.enemyMinions.Count) p.evaluatePenality -= 15;
                else p.evaluatePenality -= 5;
                foreach (Minion m in p.ownMinions) m.Ready = false;
                foreach (Minion m in p.enemyMinions) m.frozen = true;
                p.ownHero.Hp += 7;
            }
        }
    }
}