

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_037",
  "name": [
    "铸剑师",
    "Master Swordsmith"
  ],
  "text": [
    "在你的回合结束时，随机使另一个友方随从获得+1攻击力。",
    "At the end of your turn, give another random friendly minion +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 351
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_037 : SimTemplate //* Master Swordsmith
    {
        //At the end of your turn, give another random friendly minion +1 Attack.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                var tmp = turnEndOfOwner ? p.ownMinions : p.enemyMinions;
                var count = tmp.Count;
                if (count > 1)
                {
                    Minion mnn = null;
                    if (triggerEffectMinion.entitiyID != tmp[0].entitiyID)
                    {
                        mnn = tmp[0];
                    }
                    else
                    {
                        mnn = tmp[1];
                    }

                    for (var i = 1; i < count; i++)
                    {
                        if (triggerEffectMinion.entitiyID == tmp[i].entitiyID)
                        {
                            continue;
                        }

                        if (tmp[i].Hp < mnn.Hp)
                        {
                            mnn = tmp[i]; //take the weakest
                        }
                    }

                    if (mnn != null)
                    {
                        p.minionGetBuffed(mnn, 1, 0);
                    }
                }
            }
        }
    }
}