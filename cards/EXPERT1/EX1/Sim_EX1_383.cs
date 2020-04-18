using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_383",
  "name": [
    "提里奥·弗丁",
    "Tirion Fordring"
  ],
  "text": [
    "<b>圣盾</b>，<b>嘲讽</b>，<b>亡语：</b>装备一把5/3的\n灰烬使者。",
    "<b><b>Divine Shield</b>,</b> <b>Taunt</b> <b>Deathrattle:</b> Equip a 5/3 Ashbringer."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 890
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_383 : SimTemplate //tirionfordring
	{
        Chireiden.Silverfish.SimCard card = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_383t);
//    gottesschild/. spott/. todesröcheln:/ legt einen aschenbringer (5/3) an.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.equipWeapon(card,m.own);
        }

	}
}