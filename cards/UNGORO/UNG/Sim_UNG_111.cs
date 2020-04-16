using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_111",
  "name": [
    "活体法力",
    "Living Mana"
  ],
  "text": [
    "将你所有的法力水晶变成2/2的树人，当它们死亡时恢复你的法力值。",
    "Transform your Mana Crystals into 2/2 Treants. Recover the mana when they die."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 5,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41094
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_111 : SimTemplate //* Living Mana
	{
		//Transform your Mana Crystals into 2/2 minions. Recover the mana when they die.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_111t1); //Mana Treant

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
			int num = 7 - temp.Count;
			if (num > (ownplay ? p.ownMaxMana : p.enemyMaxMana))
			{
				num = ownplay ? p.ownMaxMana : p.enemyMaxMana;
				if (num > p.mana) num = p.mana;
			}
			else if (num > p.mana) num = p.mana;

			p.mana -= num;
			if (ownplay) p.ownMaxMana -= num;
			else p.enemyMaxMana -= num;

			for (int i = 7 - num; i < 7; i++)
			{
			p.callKid(kid, i, ownplay);
			}
        }
    }
}