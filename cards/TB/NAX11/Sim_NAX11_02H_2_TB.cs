using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX11_02H_2_TB",
  "name": [
    "毒云",
    "Poison Cloud"
  ],
  "text": [
    "<b>英雄技能</b>\n对所有敌方随从造成1点伤害。每死亡一个随从，召唤一个泥浆怪。",
    "<b>Hero Power</b>\nDeal 1 damage to all enemy minions. If any die, summon a slime."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 30799
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX11_02H_2_TB : SimTemplate //* Poison Cloud
    {
        // Hero Power: Deal 2 damage to all enemies. If any die, summon a slime.

        SimCard kid = CardIds.NonCollectible.Neutral.FalloutSlime; //Fallout Slime

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg);

            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            foreach (var m in ownplay ? p.enemyMinions : p.ownMinions)
            {
                if (m.Hp <= 0)
                {
                    p.callKid(this.kid, place, ownplay);
                }
            }
        }
    }
}