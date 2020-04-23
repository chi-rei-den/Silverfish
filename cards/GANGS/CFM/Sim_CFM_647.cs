

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_647",
  "name": [
    "吹箭鱼人",
    "Blowgill Sniper"
  ],
  "text": [
    "<b>战吼：</b>造成1点伤害。",
    "<b>Battlecry:</b> Deal 1 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40493
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_647 : SimTemplate //* Blowgill Sniper
    {
        // Battlecry: Deal 1 damage.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(target, 1);
        }
    }
}