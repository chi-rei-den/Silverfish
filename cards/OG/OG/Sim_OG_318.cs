using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_318",
  "name": [
    "艾尔文灾星霍格",
    "Hogger, Doom of Elwynn"
  ],
  "text": [
    "每当该随从受到伤害，召唤一个2/2并具有<b>嘲讽</b>的豺狼人。",
    "Whenever this minion takes damage, summon a 2/2 Gnoll with <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38944
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_318 : SimTemplate //* Hogger, Doom of Elwynn
	{
		//Whenever this minion takes damage, summon a 2/2 Gnoll with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_318t);

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg >= 1)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
					p.callKid(kid, m.zonepos, m.own);
                }
            }
        }
	}
}