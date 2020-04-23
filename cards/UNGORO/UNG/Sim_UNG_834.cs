using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_834",
  "name": [
    "喂食时间",
    "Feeding Time"
  ],
  "text": [
    "对一个随从造成$3点伤害。召唤三个1/1的翼手龙。",
    "Deal $3 damage to a minion. Summon three 1/1 Pterrordaxes."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 5,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41874
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_834 : SimTemplate //* Feeding Time
    {
        //Deal $3 damage to a minion. Summon three 1/1 Pterrordaxes.

        SimCard kid = CardIds.NonCollectible.Warlock.FeedingTime_PterrordaxToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);

            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
            p.callKid(this.kid, pos, ownplay);
            p.callKid(this.kid, pos, ownplay);
        }
    }
}