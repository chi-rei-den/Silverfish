

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_815",
  "name": [
    "燃鬃·自走炮",
    "Wickerflame Burnbristle"
  ],
  "text": [
    "<b>圣盾，嘲讽，吸血</b>",
    "<b>Divine Shield, Taunt, Lifesteal</b>"
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40636
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_815 : SimTemplate //* Wickerflame Burnbristle
    {
        // Taunt. Divine Shield. Damage dealt by his minion also heals your hero.
        //done in triggerAMinionDealedDmg (Playfield)
    }
}