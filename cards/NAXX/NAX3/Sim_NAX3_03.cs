

/* _BEGIN_TEMPLATE_
{
  "id": "NAX3_03",
  "name": [
    "死灵毒药",
    "Necrotic Poison"
  ],
  "text": [
    "消灭一个随从。",
    "Destroy a minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1868
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX3_03 : SimTemplate //* Necrotic Poison
    {
        // Destroy a minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }
    }
}