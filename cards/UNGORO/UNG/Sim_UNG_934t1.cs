using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_934t1",
  "name": [
    "萨弗拉斯",
    "Sulfuras"
  ],
  "text": [
    "<b>战吼：</b>你的英雄技能变为“随机对一个敌人造成8点伤害”。",
    "<b>Battlecry:</b> Your Hero Power becomes 'Deal 8 damage to a random enemy.'"
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 3,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41426
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_934t1 : SimTemplate //* Sulfuras
	{
		//Battlecry: Your Hero Power: becomes 'Deal 8 damage to a random enemy.'

        Chireiden.Silverfish.SimCard weapon = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.UNG_934t1);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
            p.setNewHeroPower(Chireiden.Silverfish.SimCard.BRM_027p, ownplay); // DIE, INSECT!
        }
    }
}