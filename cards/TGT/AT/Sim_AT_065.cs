using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_065",
  "name": [
    "国王护卫者",
    "King's Defender"
  ],
  "text": [
    "<b>战吼：</b>如果你控制任何具有<b>嘲讽</b>的随从，便获得+1耐久度。",
    "<b>Battlecry:</b> If you have a minion with <b>Taunt</b>, gain +1 Durability."
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2756
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_065 : SimTemplate //* King's Defender
	{
		//Battlecry: If you have a minion with Taunt, gain +1 Durability.

        SimCard weapon = CardIds.Collectible.Warrior.KingsDefender;

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);

            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.taunt)
                {
                    if (ownplay) p.ownWeapon.Durability++;
                    else p.enemyWeapon.Durability++;
                    break;
                }
            }
		}
	}
}