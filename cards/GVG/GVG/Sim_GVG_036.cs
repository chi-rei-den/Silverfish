using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

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

        SimCard weapon = CardIds.Collectible.Shaman.Powermace;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            var temp = m.own ? p.ownMinions : p.enemyMinions;
            if (temp.Count >= 1)
            {
                var sum = 1000;
                Minion t = null;

                foreach (var mnn in temp)
                {
                    if (mnn.handcard.card.Race == Race.MECHANICAL)
                    {
                        var s = mnn.maxHp + mnn.Angr;
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