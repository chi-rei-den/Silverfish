

/* _BEGIN_TEMPLATE_
{
  "id": "OG_151",
  "name": [
    "恩佐斯的触须",
    "Tentacle of N'Zoth"
  ],
  "text": [
    "<b>亡语：</b>对所有随从造成1点伤害。",
    "<b>Deathrattle:</b> Deal 1 damage to all minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38532
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_151 : SimTemplate //* Tentacle of N'Zoth
    {
        //Deathrattle: Deal 1 damage to all minions.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(1);
        }
    }
}