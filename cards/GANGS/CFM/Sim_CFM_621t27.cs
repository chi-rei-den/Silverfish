using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t27",
  "name": [
    "冰盖草",
    "Icecap"
  ],
  "text": [
    "随机<b>冻结</b>三个敌方随从。",
    "<b>Freeze</b> 3 random enemy minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41623
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t27 : SimTemplate //* Icecap
    {
        // Freeze: 3 random enemy minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var temp = ownplay ? p.enemyMinions : p.ownMinions;
            if (temp.Count > 3)
            {
                var anz = 0;
                target = p.searchRandomMinion(temp, SearchMode.LowHealth);
                if (target != null && !target.frozen)
                {
                    p.minionGetFrozen(target);
                    anz++;
                }

                foreach (var m in temp)
                {
                    if (!m.frozen)
                    {
                        p.minionGetFrozen(m);
                        anz++;
                        if (anz > 2)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (var m in temp)
                {
                    p.minionGetFrozen(m);
                }
            }
        }
    }
}