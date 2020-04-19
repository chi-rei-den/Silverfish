using Chireiden.Silverfish;
using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_246",
  "name": [
    "妖术",
    "Hex"
  ],
  "text": [
    "使一个随从变形成为一个0/1并具有<b>嘲讽</b>的青蛙。",
    "Transform a minion into a 0/1 Frog with <b>Taunt</b>."
  ],
  "CardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 766
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_246 : SimTemplate //hex
	{
        SimCard card = CardIds.NonCollectible.Neutral.Frog;
//    verwandelt einen diener in einen frosch (0/1) mit spott/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionTransform(target, card);
		}

	}
}