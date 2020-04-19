using Chireiden.Silverfish;
using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_013t",
  "name": [
    "法力过剩",
    "Excess Mana"
  ],
  "text": [
    "抽一张牌。<i>（你最多可以拥有\n十个法力水晶。）</i>",
    "Draw a card. <i>(You can only have 10 Mana in your tray.)</i>"
  ],
  "CardClass": "DRUID",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "CORE",
  "collectible": null,
  "dbfId": 1725
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_013t : SimTemplate //excessmana
	{

//    zieht eine karte. i&gt;(ihr könnt nur 10 mana in eurer leiste haben.)/i&gt;
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(SimCard.None, ownplay);
		}

	}
}