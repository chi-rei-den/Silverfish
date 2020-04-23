using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_245",
  "name": [
    "黑色卫士",
    "Blackguard"
  ],
  "text": [
    "每当你的英雄获得治疗时，便随机对一个敌方随从造成等量的\n伤害。",
    "Whenever your hero is healed, deal that much damage to a random enemy minion."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42825
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_245 : SimTemplate //* Blackguard
    {
        // Whenever your hero is healed, deal that much damage to a random enemy minion.

        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            var dmg = charsGotHealed;
            Minion target = null;
            if (triggerEffectMinion.own)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(dmg, true);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, SearchMode.HighAttack); //damage the Highest (pessimistic)
            }

            if (target != null)
            {
                p.minionGetDamageOrHeal(target, dmg);
            }
        }
    }
}