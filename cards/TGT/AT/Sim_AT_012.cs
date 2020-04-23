

/* _BEGIN_TEMPLATE_
{
  "id": "AT_012",
  "name": [
    "暗影子嗣",
    "Spawn of Shadows"
  ],
  "text": [
    "<b>激励：</b>对每个英雄造成4点伤害。",
    "<b>Inspire:</b> Deal 4 damage to each hero."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2551
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_012 : SimTemplate //* Spawn of Shadows
    {
        //Inspire :Deal 4 damage to each hero.

        public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own)
            {
                p.minionGetDamageOrHeal(p.enemyHero, 4);
                p.minionGetDamageOrHeal(p.ownHero, 4);
            }
        }
    }
}