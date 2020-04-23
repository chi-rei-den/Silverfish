

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_058",
  "name": [
    "日怒保卫者",
    "Sunfury Protector"
  ],
  "text": [
    "<b>战吼：</b>使相邻的随从获得<b>嘲讽</b>。",
    "<b>Battlecry:</b> Give adjacent minions <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 891
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_058 : SimTemplate //* sunfuryprotector
    {
        //Battlecry: Give adjacent minions Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    if (!m.taunt)
                    {
                        m.taunt = true;
                        if (m.own)
                        {
                            p.anzOwnTaunt++;
                        }
                        else
                        {
                            p.anzEnemyTaunt++;
                        }
                    }
                }
            }
        }
    }
}