using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_123",
  "name": [
    "冰喉",
    "Chillmaw"
  ],
  "text": [
    "<b>嘲讽，亡语：</b>\n如果你的手牌中有龙牌，则对所有随从造成3点伤害。",
    "[x]<b>Taunt</b>\n<b>Deathrattle:</b> If you're holding\na Dragon, deal 3 damage\nto all minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2682
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_123 : SimCard //* Chillmaw
	{
		//Taunt Deathrattle: If you're holding a Dragon, deal 3 damage to all minions.

		public override void onDeathrattle(Playfield p, Minion m)
        {
			if(m.own)
			{
				bool dragonInHand = false;
				foreach (Handmanager.Handcard hc in p.owncards)
				{
					if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON)
					{
						dragonInHand = true;
						break;
					}
				}
				if(dragonInHand) p.allMinionsGetDamage(3);
			}
			else
			{
				if (p.enemyAnzCards >= 1) p.allMinionsGetDamage(3);
			}
        }
    }
}