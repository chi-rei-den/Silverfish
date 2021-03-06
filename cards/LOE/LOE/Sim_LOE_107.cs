

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_107",
  "name": [
    "诡异的雕像",
    "Eerie Statue"
  ],
  "text": [
    "除非它是战场上唯一的一个随从，否则无法进行攻击。",
    "Can’t attack unless it’s the only minion on the battlefield."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 9107
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_107 : SimTemplate //* Eerie Statue
    {
        //Can't attack unless it's the only minion on the battlefield.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (!m.silenced)
            {
                m.cantAttack = p.ownMinions.Count + p.enemyMinions.Count > 0 ? true : false;
                m.updateReadyness();
            }
        }

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            if (!m.silenced)
            {
                var minionsOnBoard = 0;
                foreach (var mnn in p.ownMinions)
                {
                    if (mnn.Hp > 0)
                    {
                        minionsOnBoard++;
                    }
                }

                foreach (var mnn in p.enemyMinions)
                {
                    if (mnn.Hp > 0)
                    {
                        minionsOnBoard++;
                    }
                }

                m.cantAttack = minionsOnBoard > 0 ? true : false;
                m.updateReadyness();
            }
        }
    }
}