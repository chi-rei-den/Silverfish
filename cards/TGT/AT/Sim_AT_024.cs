using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_024",
  "name": [
    "恶魔融合",
    "Demonfuse"
  ],
  "text": [
    "使一个恶魔获得+3/+3，使你的对手获得一个法力水晶。",
    "Give a Demon +3/+3. Give your opponent a Mana Crystal."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2535
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_024 : SimCard //* Demonfuse
	{
		//Give a Demon +3/+3. Give your opponent a Mana Crystal.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 3, 3);
			
			if (ownplay)
            {
                p.enemyMaxMana = Math.Min(10, p.enemyMaxMana+1);
            }
            else
            {
                p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            }
		}
	}
}