using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_790",
  "name": [
    "卑劣的脏鼠",
    "Dirty Rat"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>使你的对手随机从手牌中召唤一个随从。",
    "[x]<b>Taunt</b>\n<b>Battlecry:</b> Your opponent\nsummons a random minion\nfrom their hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 41567
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_790 : SimTemplate //* Dirty Rat
    {
        // Taunt. Battlecry: Your opponent summons a random minion from their hand.

        SimCard kid = CardIds.Collectible.Neutral.AcidicSwampOoze; //acidicswampooze

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            var zonepos = m.own ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(this.kid, zonepos, !m.own);
        }
    }
}