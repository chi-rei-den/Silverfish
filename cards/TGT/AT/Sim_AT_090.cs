

/* _BEGIN_TEMPLATE_
{
  "id": "AT_090",
  "name": [
    "穆克拉的勇士",
    "Mukla's Champion"
  ],
  "text": [
    "<b>激励：</b>使你的其他随从获得+1/+1。",
    "<b>Inspire:</b> Give your other minions +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2497
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_090 : SimTemplate //* Mukla's Champion
    {
        //Inspire: Give your other minions +1/+1.

        public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own)
            {
                var temp = own ? p.ownMinions : p.enemyMinions;
                foreach (var mnn in temp)
                {
                    if (m.entitiyID == mnn.entitiyID)
                    {
                        continue;
                    }

                    p.minionGetBuffed(mnn, 1, 1);
                }
            }
        }
    }
}