using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t28",
  "name": [
    "虚空花",
    "Netherbloom"
  ],
  "text": [
    "召唤一个8/8的恶魔。",
    "Summon an 8/8 Demon."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41624
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t28 : SimTemplate //* Netherbloom
    {
        // Summon an 8/8 Demon.

        SimCard kid = CardIds.NonCollectible.Neutral.Kazakus_KabalDemon2;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
        }
    }
}