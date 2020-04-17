using System;
using System.Collections.Generic;
using System.Text;



/* _BEGIN_TEMPLATE_
{
  "id": "BOT_911",
  "name": [
    "吵吵模组",
    "Annoy-o-Module"
  ],
  "text": [
    "<b>磁力</b>\n<b>圣盾</b>\n<b>嘲讽</b>",
    "<b>Magnetic</b>\n<b>Divine Shield</b>\n<b>Taunt</b>"
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 48993
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BOT_911 : SimCard //* 吵吵模组 Annoy-o-Module
	{
		//<b>Magnetic</b><b>Divine Shield</b><b>Taunt</b>
		//<b>磁力</b><b>圣盾</b><b>嘲讽</b>
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}