using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_016",
  "name": [
    "希尔瓦娜斯·风行者",
    "Sylvanas Windrunner"
  ],
  "text": [
    "<b>亡语：</b>随机获得一个敌方随从的控制权。",
    "<b>Deathrattle:</b> Take\ncontrol of a random\nenemy minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "HOF",
  "collectible": true,
  "dbfId": 1721
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_016 : SimTemplate //* Sylvanas Windrunner
    {
        //Deathrattle: Take control of a random enemy minion.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target;
            if (m.own)
            {
                target = p.searchRandomMinion(p.enemyMinions, SearchMode.LowHealth);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, SearchMode.HighHealth);
                if (p.isOwnTurn && target != null && target.Ready)
                {
                    p.evaluatePenality += 5;
                }
            }

            if (target != null)
            {
                p.minionGetControlled(target, m.own, false);
            }
        }
    }
}