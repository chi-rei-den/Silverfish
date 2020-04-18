using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX12_03",
  "name": [
    "巨颚",
    "Jaws"
  ],
  "text": [
    "每当一个具有<b>亡语</b>的随从死亡，便获得+2攻击力。",
    "Whenever a minion with <b>Deathrattle</b> dies, gain +2 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 1,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1892
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX12_03 : SimTemplate //* 1/5 Jaws
	{
		//Whenever a minion with Deathrattle dies, gain +2
		//Handled in triggerAMinionDied()
		
        Chireiden.Silverfish.SimCard weapon = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.NAX12_03);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}