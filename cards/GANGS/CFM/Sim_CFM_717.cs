using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_717",
  "name": [
    "青玉之爪",
    "Jade Claws"
  ],
  "text": [
    "<b>战吼：</b>召唤一个{0}的<b>青玉魔像</b>。\n<b>过载：</b>（1）",
    "<b>Battlecry:</b> Summon a{1} {0} <b>Jade Golem</b>.\n<b><b>Overload</b>:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 2,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40529
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_717 : SimTemplate //* Jade Claws
	{
		// Battlecry: Summon a Jade Golem. Overload: (1)

        Chireiden.Silverfish.SimCard weapon = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CFM_717);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);

            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getNextJadeGolem(ownplay), place, ownplay);
        }
    }
}