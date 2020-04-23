using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "LOEA16_5",
  "name": [
    "末日镜像",
    "Mirror of Doom"
  ],
  "text": [
    "召唤数个3/3的木乃伊僵尸，直到你的随从数量达到\n上限。",
    "Fill your board with 3/3 Mummy Zombies."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "LOE",
  "collectible": null,
  "dbfId": 19616
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOEA16_5 : SimTemplate //* Mirror of Doom
    {
        // Fill your board with 3/3 Mummy Zombies.
        SimCard kid = CardIds.NonCollectible.Neutral.MirrorofDoom_MummyZombieToken; //Mummy Zombie

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var MinionsCount = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(this.kid, MinionsCount, ownplay, false);
            var kids = 6 - MinionsCount;
            for (var i = 0; i < kids; i++)
            {
                p.callKid(this.kid, MinionsCount, ownplay);
            }
        }
    }
}