

/* _BEGIN_TEMPLATE_
{
  "id": "OG_096",
  "name": [
    "暮光暗愈者",
    "Twilight Darkmender"
  ],
  "text": [
    "<b>战吼：</b>如果你的克苏恩至少具有10点攻击力，便为你的英雄恢复#10点生命值。",
    "<b>Battlecry:</b> If your C'Thun  has at least 10 Attack, restore #10 Health to your hero."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38429
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_096 : SimTemplate //* Twilight Darkmender
    {
        //Battlecry: If your C'Thun has at least 10 Attack, restore 10 Health to your hero.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.anzOgOwnCThunAngrBonus + 6 > 9)
                {
                    p.minionGetDamageOrHeal(p.ownHero, -p.getMinionHeal(10));
                }
                else
                {
                    p.evaluatePenality += 6;
                }
            }
        }
    }
}