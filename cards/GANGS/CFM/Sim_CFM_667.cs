

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_667",
  "name": [
    "爆破小队",
    "Bomb Squad"
  ],
  "text": [
    "<b>战吼：</b>对一个敌方随从造成5点伤害。\n<b>亡语：</b>对你的英雄造成5点伤害。",
    "[x]<b>Battlecry:</b> Deal 5 damage\nto an enemy minion.\n<b>Deathrattle:</b> Deal 5 damage\nto your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40952
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_667 : SimTemplate //* Bomb Squad
    {
        // Battlecry: Deal 5 damage to an enemy minion. Deathrattle: Deal 5 damage to your hero.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDamageOrHeal(target, 5);
            }
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.minionGetDamageOrHeal(m.own ? p.ownHero : p.enemyHero, 5);
        }
    }
}