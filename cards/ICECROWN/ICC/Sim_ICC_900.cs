using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_900",
  "name": [
    "死灵恶鬼",
    "Necrotic Geist"
  ],
  "text": [
    "每当你的其他随从死亡时，召唤一个2/2的食尸鬼。",
    "Whenever one of your other minions dies, summon a 2/2 Ghoul."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45307
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_900 : SimTemplate //* Necrotic Geist
    {
        // Whenever one of your other minions dies, summon a 2/2 Ghoul.

        SimCard kid = CardIds.NonCollectible.Neutral.NecroticGeist_GhoulToken; //Ghoul 2/2

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            var diedMinions = m.own ? p.tempTrigger.ownMinionsDied : p.tempTrigger.enemyMinionsDied;
            if (diedMinions == 0)
            {
                return;
            }

            var residual = p.pID == m.pID ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            for (var i = 0; i < residual; i++)
            {
                p.callKid(this.kid, m.zonepos, m.own);
            }
        }
    }
}