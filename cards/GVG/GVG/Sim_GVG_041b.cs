using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_041b",
  "name": [
    "大自然的防线",
    "Nature's Defense"
  ],
  "text": [
    "召唤5个小精灵。",
    "Summon 5 Wisps."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2177
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_041b : SimTemplate //* Dark Wispers
    {
        //   Summon 5 Wisps;

        SimCard kid = CardIds.Collectible.Neutral.Wisp;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            for (var i = 0; i < 5; i++)
            {
                var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(this.kid, pos, ownplay);
            }
        }
    }
}