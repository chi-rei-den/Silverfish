

/* _BEGIN_TEMPLATE_
{
  "id": "OG_195b",
  "name": [
    "小精灵之力",
    "Big Wisps"
  ],
  "text": [
    "使你的所有随从获得+2/+2。",
    "Give your minions +2/+2."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 7,
  "rarity": null,
  "set": "OG",
  "collectible": null,
  "dbfId": 38652
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_195b : SimTemplate //* Big Wisps
    {
        // Give your minions +2/+2.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.allMinionOfASideGetBuffed(ownplay, 2, 2);
        }
    }
}