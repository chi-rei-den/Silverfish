using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_091",
  "name": [
    "秘教暗影祭司",
    "Cabal Shadow Priest"
  ],
  "text": [
    "<b>战吼：</b>获得一个攻击力小于或等于2的敌方随从的控制权。",
    "<b>Battlecry:</b> Take control of an enemy minion that has 2 or less Attack."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 272
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_091 : SimTemplate //* Cabal Shadow Priest
	{
        //Battlecry: Take control of an enemy minion that has 2 or less Attack.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
                int num = temp.Count;
                p.minionGetControlled(target, own.own, false, true);
                if (num < 7)
                {
                    foreach (Minion m in temp)
                    {
                        if (m.name == CardIds.Collectible.Neutral.KnifeJuggler && !m.silenced) m.handcard.card.Simulator.onMinionWasSummoned(p, m, temp[num]);
                    }
                }
            }
		}
	}
}