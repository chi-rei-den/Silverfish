using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_027",
  "name": [
    "镜像",
    "Mirror Image"
  ],
  "text": [
    "召唤两个0/2，并具有<b>嘲讽</b>的随从。",
    "Summon two 0/2 minions with <b>Taunt</b>."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1084
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_027 : SimCard //* mirrorimage
	{
        //Summon two 0/2 minions with Taunt.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_mirror);
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;            
            p.callKid(kid, pos, ownplay, false);
            p.callKid(kid, pos, ownplay);
		}
	}
}