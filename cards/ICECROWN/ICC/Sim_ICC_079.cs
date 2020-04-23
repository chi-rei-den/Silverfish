

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_079",
  "name": [
    "铁齿铜牙",
    "Gnash"
  ],
  "text": [
    "使你的英雄获得3点护甲值，并在本回合中获得\n+3攻击力。",
    "Give your hero +3 Attack this turn. Gain 3 Armor."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42748
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_079 : SimTemplate //* Gnash
    {
        // Give your hero +3 Attack this turn. Gain 3 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 3);
                p.minionGetTempBuff(p.ownHero, 3, 0);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 3);
                p.minionGetTempBuff(p.enemyHero, 3, 0);
            }
        }
    }
}