using System;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_164a",
  "name": [
    "快速生长",
    "Rampant Growth"
  ],
  "text": [
    "获得两个法力水晶。",
    "Gain 2 Mana Crystals."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 451
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_164a : SimTemplate //* nourish
    {
        //    Gain 2 Mana Crystals
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.mana = Math.Min(10, p.mana + 2);
                p.ownMaxMana = Math.Min(10, p.ownMaxMana + 2);
            }
            else
            {
                p.mana = Math.Min(10, p.mana + 2);
                p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 2);
            }
        }
    }
}