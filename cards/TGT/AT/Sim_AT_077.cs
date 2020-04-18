using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_077",
  "name": [
    "白银之枪",
    "Argent Lance"
  ],
  "text": [
    "<b>战吼：</b>揭示双方牌库里的一张随从牌。如果你的牌法力值消耗较大，+1耐久度。",
    "<b>Battlecry:</b> Reveal a minion in each deck. If yours costs more, +1 Durability."
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2720
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_077 : SimTemplate //* Argent Lance
	{
		//Battlecry : Reveal a minion in each deck. If yours costs more, gain +1 durability.

        Chireiden.Silverfish.SimCard w = CardIds.Collectible.Paladin.ArgentLance;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }
	}
}