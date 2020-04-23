using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_009",
  "name": [
    "罗宁",
    "Rhonin"
  ],
  "text": [
    "<b>亡语：</b>将三张奥术飞弹置入你的手牌。",
    "<b>Deathrattle:</b> Add 3 copies of Arcane Missiles to your hand."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2546
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_009 : SimTemplate //* Rhonin
    {
        //Deathrattle: Add 3 copies of Arcane Missiles to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIds.Collectible.Mage.ArcaneMissiles, m.own, true);
            p.drawACard(CardIds.Collectible.Mage.ArcaneMissiles, m.own, true);
            p.drawACard(CardIds.Collectible.Mage.ArcaneMissiles, m.own, true);
        }
    }
}