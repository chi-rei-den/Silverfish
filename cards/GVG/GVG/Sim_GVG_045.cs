using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_045",
  "name": [
    "小鬼爆破",
    "Imp-losion"
  ],
  "text": [
    "对一个随从造成$2-$4点伤害。每造成1点伤害，便召唤一个1/1的小鬼。",
    "Deal $2-$4 damage to a minion. Summon a 1/1 Imp for each damage dealt."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2013
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_045 : SimTemplate //Imp-losion
    {
        //   Deal $2-$4 damage to a minion. Summon a 1/1 Imp for each damage dealt.

        SimCard kid = CardIds.NonCollectible.Warlock.Implosion_ImpToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);

            var posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, posi, ownplay);
            posi++;
            p.callKid(this.kid, posi, ownplay);
        }
    }
}