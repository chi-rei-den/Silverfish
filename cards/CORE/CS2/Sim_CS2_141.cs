

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_141",
  "name": [
    "铁炉堡火枪手",
    "Ironforge Rifleman"
  ],
  "text": [
    "<b>战吼：</b>造成1点伤害。",
    "<b>Battlecry:</b> Deal 1 damage."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 339
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_141 : SimTemplate //ironforgerifleman
    {
//    kampfschrei:/ verursacht 1 schaden.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var dmg = 1;
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}