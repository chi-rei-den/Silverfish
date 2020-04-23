

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_712",
  "name": [
    "紫罗兰法师",
    "Violet Illusionist"
  ],
  "text": [
    "在你的回合时，你的英雄会获得<b>免疫</b>。",
    "During your turn, your hero is <b>Immune</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39313
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_712 : SimTemplate //* Violet Illusionist
    {
        //During your turn, your hero is Immune.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.ownHero.immune = true;
            }
            else
            {
                p.enemyHero.immune = true;
            }
        }

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                if (turnStartOfOwner)
                {
                    p.ownHero.immune = true;
                }
                else
                {
                    p.enemyHero.immune = true;
                }
            }
        }
    }
}