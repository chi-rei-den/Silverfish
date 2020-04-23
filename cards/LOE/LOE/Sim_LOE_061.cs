using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_061",
  "name": [
    "阿努比萨斯哨兵",
    "Anubisath Sentinel"
  ],
  "text": [
    "<b>亡语：</b>随机使一个友方随从获得+3/+3。",
    "<b>Deathrattle:</b> Give a random friendly minion +3/+3."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2933
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_061 : SimTemplate //* Anubisath Sentinel
    {
        //Deathrattle: Give a random friendly minion +3/+3.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            var target = m.own ? p.searchRandomMinion(p.ownMinions, SearchMode.LowAttack) : p.searchRandomMinion(p.enemyMinions, SearchMode.LowAttack);
            if (target != null)
            {
                p.minionGetBuffed(target, 3, 3);
            }
        }
    }
}