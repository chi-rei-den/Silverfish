using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_036",
  "name": [
    "动力战锤",
    "Powermace"
  ],
  "text": [
    "<b>亡语：</b>随机使一个友方机械获得+2/+2。",
    "<b>Deathrattle:</b> Give a random friendly Mech +2/+2."
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2004
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_036 : SimTemplate //* Powermace
    {
        //Deathrattle: Give a random friendly Mech +2/+2.

        Chireiden.Silverfish.SimCard weapon = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.GVG_036);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            if (temp.Count >= 1)
            {
                int sum = 1000;
                Minion t = null;

                foreach (Minion mnn in temp)
                {
                    if ((TAG_RACE)mnn.handcard.card.Race == TAG_RACE.MECHANICAL)
                    {
                        int s = mnn.maxHp + mnn.Angr;
                        if (s < sum)
                        {
                            t = mnn;
                            sum = s;
                        }
                    }
                }

                if (t != null && sum < 999)
                {
                    p.minionGetBuffed(t, 2, 2);
                }
            }
        }
    }
}