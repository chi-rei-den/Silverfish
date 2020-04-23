

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_021",
  "name": [
    "自爆肿胀蝠",
    "Exploding Bloatbat"
  ],
  "text": [
    "<b>亡语：</b>对所有敌方随从造成2点伤害。",
    "<b>Deathrattle:</b>\nDeal 2 damage to all enemy minions."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42320
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_021 : SimTemplate //* Exploding Bloatbat
    {
        // Deathrattle: Deal 2 damage to all enemy minions.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetDamage(!m.own, 2);
        }
    }
}