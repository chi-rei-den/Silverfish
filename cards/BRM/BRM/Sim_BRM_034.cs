

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_034",
  "name": [
    "黑翼腐蚀者",
    "Blackwing Corruptor"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，则造成3点伤害。",
    "<b>Battlecry:</b> If you're holding a Dragon, deal 3 damage."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2409
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_034 : SimTemplate //* Blackwing Corruptor
    {
        // Battlecry: If you're holding a Dragon, deal 3 damage.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDamageOrHeal(target, 3);
            }
        }
    }
}