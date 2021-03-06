

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_027",
  "name": [
    "钢铁武道家",
    "Iron Sensei"
  ],
  "text": [
    "在你的回合结束时，使另一个友方机械获得+2/+2。",
    "At the end of your turn, give another friendly Mech +2/+2."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1992
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_027 : SimTemplate //* Iron Sensei
    {
        //At the end of your turn, give another friendly Mech +2/+2.

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
                        p.minionGetBuffed(mnn, 2, 2);
                    }
                }
            }
        }
    }
}