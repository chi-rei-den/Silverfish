using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_577",
  "name": [
    "比斯巨兽",
    "The Beast"
  ],
  "text": [
    "<b>亡语：</b>\n为你的对手召唤1个3/3的芬克·恩霍尔。",
    "<b>Deathrattle:</b> Summon a 3/3 Finkle Einhorn for your opponent."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 962
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_577 : SimTemplate //* thebeast
    {
        //Deathrattle: Summon a 3/3 Finkle Einhorn for your opponent.

        SimCard c = CardIds.NonCollectible.Neutral.FinkleEinhorn; //finkleeinhorn

        public override void onDeathrattle(Playfield p, Minion m)
        {
            var pos = m.own ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(this.c, pos, !m.own);
        }
    }
}