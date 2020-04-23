

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_102",
  "name": [
    "全副武装！",
    "Armor Up!"
  ],
  "text": [
    "<b>英雄技能</b>\n获得2点护甲值。",
    "<b>Hero Power</b>\nGain 2 Armor."
  ],
  "CardClass": "WARRIOR",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 725
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_102 : SimTemplate //armorup
    {
//    heldenfähigkeit/\nerhaltet 2 rüstung.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 2);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 2);
            }
        }
    }
}