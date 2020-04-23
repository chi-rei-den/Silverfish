

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_858",
  "name": [
    "浴火者伯瓦尔",
    "Bolvar, Fireblood"
  ],
  "text": [
    "<b>圣盾</b>\n在一个友方随从失去<b>圣盾</b>后，获得+2攻击力。",
    "<b>Divine Shield</b>\nAfter a friendly minion loses <b>Divine Shield</b>, gain +2 Attack."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45392
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_858 : SimTemplate //* Bolvar, Fireblood
    {
        // Divine Shield. After a friendly minion loses Divine Shield, gain +2 Attack.

        public override void onMinionLosesDivineShield(Playfield p, Minion m, int num)
        {
            p.minionGetBuffed(m, 2 * num, 0);
        }
    }
}