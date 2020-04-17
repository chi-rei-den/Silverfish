using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX8_03",
  "name": [
    "冷酷学徒",
    "Unrelenting Trainee"
  ],
  "text": [
    "<b>亡语：</b>为你的对手召唤一个鬼灵学徒。",
    "<b>Deathrattle:</b> Summon a Spectral Trainee for your opponent."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1873
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX8_03 : SimCard //* Unrelenting Trainee
	{
//    Deathrattle:: Summon a Spectral Trainee for your opponent.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX8_03t); //Spectral Trainee
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int place = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, place, !m.own);
        }
	}
}