

/* _BEGIN_TEMPLATE_
{
  "id": "OG_280",
  "name": [
    "克苏恩",
    "C'Thun"
  ],
  "text": [
    "<b>战吼：</b>\n造成等同于该随从攻击力的伤害，随机分配到所有敌人身上。",
    "<b>Battlecry:</b> Deal damage equal to this minion's Attack randomly split among all enemies."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38857
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_280 : SimTemplate //* C'Thun
    {
        //Battlecry: Deal damage equal to this minion's Attack randomly split among all enemies.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var times = p.anzOgOwnCThunAngrBonus + 6 - own.Angr;
            if (times < 1)
            {
                times = own.Angr;
            }
            else
            {
                times += own.Angr;
            }

            p.allCharsOfASideGetRandomDamage(!own.own, times);
            p.allMinionOfASideGetDamage(!own.own, 1);
        }
    }
}