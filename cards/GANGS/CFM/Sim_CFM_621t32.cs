

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t32",
  "name": [
    "金棘草",
    "Goldthorn"
  ],
  "text": [
    "使你的所有随从获得+6生命值。",
    "Give your minions +6 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41628
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t32 : SimTemplate //* Goldthorn
    {
        // Give your minions +6 Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.allMinionOfASideGetBuffed(ownplay, 0, 6);
        }
    }
}