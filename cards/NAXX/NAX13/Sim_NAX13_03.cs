

/* _BEGIN_TEMPLATE_
{
  "id": "NAX13_03",
  "name": [
    "增压",
    "Supercharge"
  ],
  "text": [
    "使你的所有随从获得+2生命值。",
    "Give your minions +2 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1976
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX13_03 : SimTemplate //* Supercharge
    {
        // Give your minions +2 Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.allMinionOfASideGetBuffed(ownplay, 0, 2);
        }
    }
}