using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_207",
  "name": [
    "无面召唤者",
    "Faceless Summoner"
  ],
  "text": [
    "<b>战吼：</b>随机召唤一个法力值消耗为（3）的随从。",
    "<b>Battlecry:</b> Summon a random 3-Cost minion."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38725
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_207 : SimTemplate //* Faceless Summoner
	{
		//Battlecry: Summon a random 3-Cost minion.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_106); //Light's Champion
				
		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> list = (m.own) ? p.ownMinions : p.enemyMinions;
            int anz = list.Count;
            p.callKid(kid, m.zonepos, m.own);
            if (anz < 7 && !list[m.zonepos].taunt)
            {
                list[m.zonepos].taunt = true;
                if (m.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
	}
}