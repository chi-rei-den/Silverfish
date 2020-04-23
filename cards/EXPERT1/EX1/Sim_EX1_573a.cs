

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_573a",
  "name": [
    "半神的恩赐",
    "Demigod's Favor"
  ],
  "text": [
    "使你的所有其他随从获得+2/+2。",
    "Give your other minions +2/+2."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 9,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1145
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_573a : SimTemplate //* Demigod's Favor
    {
        //Give your other minions +2/+2.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var temp = ownplay ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (target.entitiyID != m.entitiyID)
                {
                    p.minionGetBuffed(m, 2, 2);
                }
            }
        }
    }
}