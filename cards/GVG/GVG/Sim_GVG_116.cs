using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_116",
  "name": [
    "瑟玛普拉格",
    "Mekgineer Thermaplugg"
  ],
  "text": [
    "每当一个敌方随从死亡，召唤一个\n麻风侏儒。",
    "Whenever an enemy minion dies, summon a Leper Gnome."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2084
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_116 : SimTemplate //* Mekgineer Thermaplugg
    {
        //   Whenever an enemy minion dies, summon a Leper Gnome.
        SimCard kid = CardIds.Collectible.Neutral.LeperGnome; //lepergnome

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            var diedMinions = m.own ? p.tempTrigger.enemyMinionsDied : p.tempTrigger.ownMinionsDied;
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