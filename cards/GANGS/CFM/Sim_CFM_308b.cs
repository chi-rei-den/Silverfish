

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_308b",
  "name": [
    "遗忘法力",
    "Forgotten Mana"
  ],
  "text": [
    "复原你的法力水晶。",
    "Refresh your Mana Crystals."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41959
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_308b : SimTemplate //* Forgotten Mana
    {
        // Refresh your Mana Crystals.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.mana = p.ownMaxMana;
            }
            else
            {
                p.mana = p.enemyMaxMana;
            }
        }
    }
}