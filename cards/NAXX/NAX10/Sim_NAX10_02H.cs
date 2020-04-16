using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX10_02H",
  "name": [
    "铁钩",
    "Hook"
  ],
  "text": [
    "<b>风怒</b>，<b>亡语：</b>\n将这把武器移回你的手牌。",
    "<b>Windfury</b>\n<b>Deathrattle:</b> Put this weapon into your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2132
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX10_02H : SimTemplate //* Hook
	{
		//Windfury. Deathrattle: Put this weapon into your hand.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX10_02H);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.drawACard(CardDB.cardIDEnum.NAX10_02H, m.own, true);
        }
    }
}