using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_026",
  "name": [
    "饥饿的巨龙",
    "Hungry Dragon"
  ],
  "text": [
    "<b>战吼：</b>为你的对手随机召唤一个法力值消耗为（1）的随从。",
    "<b>Battlecry:</b> Summon a random 1-Cost minion for your opponent."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2283
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_026 : SimTemplate //* Hungry Dragon
	{
		// Battlecry: Summon a random 1-Cost minion for your opponent.
        		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_614t); //flameofazzinoth

		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int zonepos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, zonepos, !m.own);
        }
	}
}