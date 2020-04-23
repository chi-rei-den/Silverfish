

/* _BEGIN_TEMPLATE_
{
  "id": "OG_047",
  "name": [
    "野性之怒",
    "Feral Rage"
  ],
  "text": [
    "<b>抉择：</b>使你的英雄在本回合中获得+4攻击力；或者获得8点护甲值。",
    "<b>Choose One -</b> Give your hero +4 Attack this turn; or Gain 8 Armor."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38334
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_047 : SimTemplate //* Feral Rage
    {
        //Choose One - Give your hero +4 attack this turn; or Gain 8 armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || p.ownFandralStaghelm > 0 && ownplay)
            {
                if (ownplay)
                {
                    p.minionGetTempBuff(p.ownHero, 4, 0);
                }
                else
                {
                    p.minionGetTempBuff(p.enemyHero, 4, 0);
                }
            }

            if (choice == 2 || p.ownFandralStaghelm > 0 && ownplay)
            {
                if (ownplay)
                {
                    p.minionGetArmor(p.ownHero, 8);
                }
                else
                {
                    p.minionGetArmor(p.enemyHero, 8);
                }
            }
        }
    }
}