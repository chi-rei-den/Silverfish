using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_075",
  "name": [
    "战马训练师",
    "Warhorse Trainer"
  ],
  "text": [
    "你的白银之手新兵获得+1攻击力。",
    "Your Silver Hand Recruits have +1 Attack."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2515
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_075 : SimTemplate //* Warhorse Trainer
    {
        //Your Silver Hand Recruits have +1 Attack.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnWarhorseTrainer++;
            }
            else
            {
                p.anzEnemyWarhorseTrainer++;
            }

            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                {
                    p.minionGetBuffed(m, 1, 0);
                }
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnWarhorseTrainer--;
            }
            else
            {
                p.anzEnemyWarhorseTrainer--;
            }

            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                {
                    p.minionGetBuffed(m, -1, 0);
                }
            }
        }
    }
}