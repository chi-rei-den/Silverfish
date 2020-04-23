using Chireiden.Silverfish;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_002",
  "name": [
    "火妖",
    "Flamewaker"
  ],
  "text": [
    "在你施放一个法术后，造成2点伤害，随机分配到所有敌人身上。",
    "After you cast a spell, deal 2 damage randomly split among all enemies."
  ],
  "CardClass": "MAGE",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2275
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_002 : SimTemplate //* Flamewaker
    {
        // After you cast a spell, deal 2 damage randomly split among all enemies.

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.Type == CardType.SPELL)
            {
                var target = ownplay ? p.enemyHero : p.ownHero;
                p.minionGetDamageOrHeal(target, 1);

                var temp = ownplay ? p.enemyMinions : p.ownMinions;
                if (temp.Count > 0)
                {
                    target = p.searchRandomMinion(temp, SearchMode.LowHealth);
                }

                if (target == null)
                {
                    target = ownplay ? p.enemyHero : p.ownHero;
                }

                p.minionGetDamageOrHeal(target, 1);
            }
        }
    }
}