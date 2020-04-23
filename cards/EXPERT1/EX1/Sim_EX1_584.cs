

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_584",
  "name": [
    "年迈的法师",
    "Ancient Mage"
  ],
  "text": [
    "<b>战吼：</b>使相邻的随从获得<b>法术伤害+1</b>。",
    "<b>Battlecry:</b> Give adjacent minions <b>Spell Damage +1</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 915
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_584 : SimTemplate //* Ancient Mage
    {
        //Battlecry: Give adjacent minions Spell Damage +1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    m.spellpower++;
                    if (own.own)
                    {
                        p.spellpower++;
                    }
                    else
                    {
                        p.enemyspellpower++;
                    }
                }
            }
        }
    }
}