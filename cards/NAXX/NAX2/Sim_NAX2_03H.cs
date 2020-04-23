using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX2_03H",
  "name": [
    "火焰之雨",
    "Rain of Fire"
  ],
  "text": [
    "<b>英雄技能</b>\n你的对手每有一张手牌，便发射一枚飞弹。",
    "<b>Hero Power</b>\nFire a missile for each card in your opponent's hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 1,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2105
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX2_03H : SimTemplate //Rain of Fire
    {
//  Hero Power (Heroic): Fire a missile for each card in your opponent's hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = 1;
            var cardCount = 0;
            if (ownplay)
            {
                cardCount = p.enemyAnzCards;
                dmg += p.ownHeroPowerExtraDamage;
                if (p.doublepriest >= 1)
                {
                    dmg *= 2 * p.doublepriest;
                }
            }
            else
            {
                cardCount = p.owncards.Count;
                dmg += p.enemyHeroPowerExtraDamage;
                if (p.enemydoublepriest >= 1)
                {
                    dmg *= 2 * p.enemydoublepriest;
                }
            }

            for (var i = 0; i < cardCount; i++)
            {
                target = ownplay ? p.searchRandomMinion(p.enemyMinions, SearchMode.LowHealth, SearchMode.HighAttack) : p.searchRandomMinion(p.ownMinions, SearchMode.LowHealth, SearchMode.HighAttack);
                if (target == null)
                {
                    target = ownplay ? p.enemyHero : p.ownHero;
                }

                p.minionGetDamageOrHeal(target, dmg);
            }
        }
    }
}