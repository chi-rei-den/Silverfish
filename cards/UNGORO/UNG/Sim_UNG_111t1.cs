using System;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_111t1",
  "name": [
    "法力树人",
    "Mana Treant"
  ],
  "text": [
    "<b>亡语：</b>获得一个空的法力水晶。",
    "<b>Deathrattle:</b> Gain an empty Mana Crystal."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 2,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41432
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_111t1 : SimTemplate //* Mana Treant
    {
        //Deathrattle: Gain an empty Mana Crystal.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            }
            else
            {
                p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 1);
            }
        }
    }
}