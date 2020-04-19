using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_025",
  "name": [
    "附灵术",
    "Kara Kazham!"
  ],
  "text": [
    "召唤一个1/1的蜡烛，2/2的扫帚和3/3的茶壶。",
    "Summon a 1/1 Candle, 2/2 Broom, and 3/3 Teapot."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 5,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39197
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_025 : SimTemplate //* Kara Kazham!
	{
		//Summon a 1/1 Candle, 2/2 Broom, and 3/3 Teapot.
		
        SimCard c1 = CardIds.NonCollectible.Warlock.KaraKazham_Candle;//Candle
        SimCard c2 = CardIds.NonCollectible.Warlock.KaraKazham_Broom;//Broom
        SimCard c3 = CardIds.NonCollectible.Warlock.KaraKazham_Teapot;//Teapot
        
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)?  p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(c1, pos, ownplay, false);
            p.callKid(c2, pos, ownplay);
            p.callKid(c3, pos, ownplay);
		}
	}
}