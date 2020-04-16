using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_316",
  "name": [
    "瘟疫鼠群",
    "Rat Pack"
  ],
  "text": [
    "<b>亡语：</b>召唤若干个1/1的老鼠，数量等同于该随从的攻击力。",
    "[x]<b>Deathrattle:</b> Summon a\nnumber of 1/1 Rats equal\n to this minion's Attack."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40428
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_316 : SimTemplate //* Rat Pack
	{
		// Deathrattle: Summon a number of 1/1 Rats equal to this minion's Attack.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_316t); //1/1 Rat

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int anz = m.Angr;
            if (anz > 0)
            {
                p.callKid(kid, m.zonepos - 1, m.own, false);
                anz--;                
                for (int i = 0; i < anz; i++)
                {
                    p.callKid(kid, m.zonepos - 1, m.own);
                }
            }
        }
    }
}