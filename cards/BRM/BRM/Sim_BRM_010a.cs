using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_010a",
  "name": [
    "火焰猎豹形态",
    "Firecat Form"
  ],
  "text": [
    null,
    null
  ],
  "CardClass": "DRUID",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": null,
  "dbfId": 2293
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_010a : SimTemplate //* Firecat Form
    {
        // Transform into a 5/2 minion.

        SimCard cat = CardIds.NonCollectible.Druid.DruidoftheFlame_DruidOfTheFlameToken1;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, this.cat);
        }
    }
}