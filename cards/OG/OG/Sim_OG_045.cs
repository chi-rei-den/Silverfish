using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_045",
  "name": [
    "寄生感染",
    "Infest"
  ],
  "text": [
    "使你的所有随从获得\n“<b>亡语：</b>随机将一张野兽牌置入你的手牌”。",
    "Give your minions \"<b>Deathrattle:</b> Add a random Beast to your hand.\""
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38329
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_045 : SimTemplate //* Infest
    {
        //Give your minions "Deathrattle: Add a random Beast to your hand."

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                m.infest++;
            }
        }
    }
}