using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_314",
  "name": [
    "化血为脓",
    "Blood To Ichor"
  ],
  "text": [
    "对一个随从造成$1点伤害，如果它依然存活，则召唤一个2/2的泥浆怪。",
    "Deal $1 damage to a minion. If it survives, summon a 2/2 Slime."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38918
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_314 : SimTemplate //* Blood to Ichor
    {
        //Deal 1 damage to a minion. If it survives, summon a 2/2 Slime.

        SimCard kid = CardIds.NonCollectible.Neutral.InfestedTauren_Slime;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            if (target.Hp > dmg || target.immune || target.divineshild)
            {
                var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(this.kid, pos, ownplay);
            }

            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}