

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_807",
  "name": [
    "硬壳清道夫",
    "Strongshell Scavenger"
  ],
  "text": [
    "<b>战吼：</b>使你具有<b>嘲讽</b>的随从获得+2/+2。",
    "<b>Battlecry:</b> Give your <b>Taunt</b> minions +2/+2."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43022
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_807 : SimTemplate //* Strongshell Scavenger
    {
        // Battlecry: Give your Taunt minions +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            var temp = m.own ? p.ownMinions : p.enemyMinions;
            foreach (var mnn in temp)
            {
                if (mnn.taunt)
                {
                    p.minionGetBuffed(mnn, 2, 2);
                }
            }
        }
    }
}