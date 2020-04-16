using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_211",
  "name": [
    "兽群呼唤",
    "Call of the Wild"
  ],
  "text": [
    "召唤所有三种动物伙伴。",
    "Summon all three Animal Companions."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 8,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38727
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_211 : SimTemplate //* Call of the Wild
	{
		//Summon all 3 Animal Companions.
		
        CardDB.Card c1 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_034);//Huffer
        CardDB.Card c2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_033);//Leokk
        CardDB.Card c3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_032);//Misha
        
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)?  p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(c1, pos, ownplay, false);
            p.callKid(c2, pos, ownplay);
            p.callKid(c3, pos, ownplay);
		}
	}
}