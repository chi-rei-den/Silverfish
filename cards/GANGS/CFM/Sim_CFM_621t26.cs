

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t26",
  "name": [
    "石鳞鱼油",
    "Stonescale Oil"
  ],
  "text": [
    "获得10点护甲值。",
    "Gain 10 Armor."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41622
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t26 : SimTemplate //* Stonescale Oil
    {
        // Gain 10 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 10);
        }
    }
}