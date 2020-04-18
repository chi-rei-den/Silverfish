using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX10_02",
  "name": [
    "铁钩",
    "Hook"
  ],
  "text": [
    "<b>亡语：</b>将这把武器移回你的手牌。",
    "<b>Deathrattle:</b> Put this weapon into your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1885
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX10_02 : SimTemplate //* Hook
	{
		//Deathrattle: Put this weapon into your hand.

        Chireiden.Silverfish.SimCard weapon = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.NAX10_02);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.drawACard(Chireiden.Silverfish.SimCard.NAX10_02, m.own, true);
        }
    }
}