using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_829t1",
  "name": [
    "虚空传送门",
    "Nether Portal"
  ],
  "text": [
    "打开一座会永久召唤3/2小鬼的传送门。",
    "Open a permanent portal that summons 3/2 Imps."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41942
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_829t1 : SimTemplate //* Nether Portal
    {
        //Open a permanent portal that summons 3/2 Imps.

        SimCard kid = CardIds.NonCollectible.Warlock.LakkariSacrifice_NetherPortalToken2; //Nether Portal

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
            p.evaluatePenality -= 15;
        }
    }
}