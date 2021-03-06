using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t20",
  "name": [
    "虚空花",
    "Netherbloom"
  ],
  "text": [
    "召唤一个5/5的恶魔。",
    "Summon a 5/5 Demon."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41616
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t20 : SimTemplate //* Netherbloom
    {
        // Summon a 5/5 Demon.

        SimCard kid = CardIds.NonCollectible.Neutral.Kazakus_KabalDemon1;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
        }
    }
}