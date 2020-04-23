

/* _BEGIN_TEMPLATE_
{
  "id": "OG_120",
  "name": [
    "阿诺玛鲁斯",
    "Anomalus"
  ],
  "text": [
    "<b>亡语：</b>对所有随从造成8点伤害。",
    "<b>Deathrattle:</b> Deal 8 damage to all minions."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38463
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_120 : SimTemplate //* Anomalus
    {
        //Deathrattle: Deal 8 damage to all minions.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(8);
        }
    }
}