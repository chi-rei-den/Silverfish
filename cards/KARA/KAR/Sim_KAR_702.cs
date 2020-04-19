using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_702",
  "name": [
    "展览馆法师",
    "Menagerie Magician"
  ],
  "text": [
    "<b>战吼：</b>随机使一个友方野兽，龙和鱼人获得+2/+2。",
    "<b>Battlecry:</b> Give a random friendly Beast, Dragon, and Murloc +2/+2."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39269
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_702 : SimTemplate //* Menagerie Magician
	{
		//Battlecry: Give a random Beast, Dragon and Murloc +2/+2.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            if (temp.Count >= 1)
            {
                Minion Beast = null;
                Minion Dragon = null;
                Minion Murloc = null;
				
                foreach (Minion m in temp)
                {
                    switch ((Race)m.handcard.card.Race)
					{
						case Race.PET:
							if (Beast == null) Beast = m;
							continue;
						case Race.DRAGON:
							if (Dragon == null) Dragon = m;
							continue;
                        case Race.MURLOC:
							if (Murloc == null) Murloc = m;
							continue;
					}
                }
				
				if (Beast != null) p.minionGetBuffed(Beast, 2, 2);
				if (Dragon != null) p.minionGetBuffed(Dragon, 2, 2);
				if (Murloc != null) p.minionGetBuffed(Murloc, 2, 2);
            }
		}
	}
}