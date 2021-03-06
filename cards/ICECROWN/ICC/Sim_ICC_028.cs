

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_028",
  "name": [
    "阳焰瓦格里",
    "Sunborne Val'kyr"
  ],
  "text": [
    "<b>战吼：</b>使相邻的随从获得+2生命值。",
    "<b>Battlecry:</b> Give adjacent minions +2 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42440
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_028 : SimTemplate //* Sunborne Val'kyr
    {
        // Battlecry: Give adjacent minions +2 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    p.minionGetBuffed(m, 0, 2);
                }
            }
        }
    }
}