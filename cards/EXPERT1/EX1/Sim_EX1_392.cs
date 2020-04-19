using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_392",
  "name": [
    "战斗怒火",
    "Battle Rage"
  ],
  "text": [
    "每有一个受伤的友方角色，便抽一张牌。",
    "Draw a card for each damaged friendly character."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 400
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_392 : SimTemplate //battlerage
	{

//    zieht eine karte für jeden verletzten befreundeten charakter.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay)? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp )
            {
                if (mnn.wounded)
                {
                    p.drawACard(SimCard.None, ownplay);
                }
            }
            if (ownplay && p.ownHero.Hp < 30) p.drawACard(SimCard.None, true);
            if (!ownplay && p.enemyHero.Hp < 30) p.drawACard(SimCard.None, false);

		}

	}
}