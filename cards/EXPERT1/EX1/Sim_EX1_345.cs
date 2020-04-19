using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_345",
  "name": [
    "控心术",
    "Mindgames"
  ],
  "text": [
    "随机将你对手的牌库中的一张随从牌的复制置入战场。",
    "Put a copy of\na random minion from\nyour opponent's deck into the battlefield."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 4,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 145
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_345 : SimTemplate //* Mindgames
	{
        // Put a copy of a random minion from your opponent's deck into the battlefield.

        Chireiden.Silverfish.SimCard copymin = CardIds.Collectible.Neutral.ChillwindYeti; // we take a icewindjety :D

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (p.enemyDeckSize < 1) copymin = CardIds.NonCollectible.Priest.Mindgames_ShadowOfNothingToken; // Shadow of Nothing
            p.callKid(copymin, p.ownMinions.Count, ownplay, false);
		}
	}
}