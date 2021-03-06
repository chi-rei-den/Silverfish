using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t10",
  "name": [
    "虚空花",
    "Netherbloom"
  ],
  "text": [
    "召唤一个2/2的恶魔。",
    "Summon a 2/2 Demon."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41582
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t10 : SimTemplate //* Netherbloom
    {
        // Summon a 2/2 Demon.

        SimCard kid = CardIds.NonCollectible.Neutral.Kazakus_KabalDemon3;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
        }
    }
}