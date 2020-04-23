

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_308a",
  "name": [
    "遗忘护甲",
    "Forgotten Armor"
  ],
  "text": [
    "获得10点护甲值。",
    "Gain 10 Armor."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41958
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_308a : SimTemplate //* Forgotten Armor
    {
        // Gain 10 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 10);
        }
    }
}