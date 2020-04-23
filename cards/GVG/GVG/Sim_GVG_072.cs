using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_072",
  "name": [
    "暗影打击装甲",
    "Shadowboxer"
  ],
  "text": [
    "每当一个随从获得治疗，便随机对一个敌人造成1点伤害。",
    "Whenever a minion is healed, deal 1 damage to a random enemy."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2040
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_072 : SimTemplate //* Shadowboxer
    {
        // Whenever a character is healed, deal 1 damage to a random enemy.  

        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            Minion target = null;

            if (triggerEffectMinion.own)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(charsGotHealed);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, SearchMode.HighAttack); //damage the Highest (pessimistic)
                if (target == null)
                {
                    target = p.ownHero;
                }
            }

            p.minionGetDamageOrHeal(target, charsGotHealed, true);
        }
    }
}