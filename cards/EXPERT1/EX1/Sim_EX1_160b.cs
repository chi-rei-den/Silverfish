

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_160b",
  "name": [
    "兽群领袖",
    "Leader of the Pack"
  ],
  "text": [
    "使你所有的随从获得+1/+1。",
    "Give your minions +1/+1."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 835
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_160b : SimTemplate //leaderofthepack
    {
//    verleiht euren dienern +1/+1.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var temp = ownplay ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                p.minionGetBuffed(m, 1, 1);
            }
        }
    }
}