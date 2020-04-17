using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_195",
  "name": [
    "上古之神的小精灵",
    "Wisps of the Old Gods"
  ],
  "text": [
    "<b>抉择：</b>召唤七个1/1的小精灵；或者使你的所有随从获得+2/+2。",
    "<b>Choose One -</b> Summon seven 1/1 Wisps; or Give your minions +2/+2."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 7,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38655
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_195 : SimCard //* Wisps of the Old Gods
	{
		//Choose One - Summon seven 1/1 Wisps; or Give your minions +2/+2.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231);
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                for (int i = 0; i < 7; i++)
                {
                    int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                    p.callKid(kid, pos, ownplay);
                }
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                p.allMinionOfASideGetBuffed(ownplay, 2, 2);
            }
        }
    }
}