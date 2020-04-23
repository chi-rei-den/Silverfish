

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_658",
  "name": [
    "后院保镖",
    "Backroom Bouncer"
  ],
  "text": [
    "每当一个友方随从死亡，便获得+1\n攻击力。",
    "Whenever a friendly minion dies, gain +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40931
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_658 : SimTemplate //* Backroom Bouncer
    {
        // Whenever a friendly minion dies, gain +1 Attack.

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            if (m.own == diedMinion.own)
            {
                var diedMinions = m.own ? p.tempTrigger.ownMinionsDied : p.tempTrigger.enemyMinionsDied;
                if (diedMinions != 0)
                {
                    var residual = p.pID == m.pID ? diedMinions - m.extraParam2 : diedMinions;
                    m.pID = p.pID;
                    m.extraParam2 = diedMinions;
                    p.minionGetBuffed(m, residual, 0);
                }
            }
        }
    }
}