using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_038",
  "name": [
    "达纳苏斯豹骑士",
    "Darnassus Aspirant"
  ],
  "text": [
    "<b>战吼：</b>获得一个空的法力水晶。\n<b>亡语：</b>失去一个法力水晶。",
    "<b>Battlecry:</b> Gain an empty Mana Crystal.\n<b>Deathrattle:</b> Lose a Mana Crystal."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2782
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_038 : SimTemplate //* Darnassus Aspirant
    {
		//Battlecry: Gain an empty mana crystal.
		//Deathrattle: Destroy a mana crystal.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            else p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 1);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
			if (m.own) p.ownMaxMana--;
            else p.enemyMaxMana--;
        }
    }
}