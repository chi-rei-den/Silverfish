using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_122",
  "name": [
    "山谷之王穆克拉",
    "Mukla, Tyrant of the Vale"
  ],
  "text": [
    "<b>战吼：</b>将两个香蕉置入你的手牌。",
    "<b>Battlecry:</b> Add 2 Bananas to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38468
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_122 : SimTemplate //* Mukla, Tyrant of the Vale
    {
        //Battlecry: Add 2 Bananas to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIds.NonCollectible.Neutral.Bananas, own.own, true);
            p.drawACard(CardIds.NonCollectible.Neutral.Bananas, own.own, true);
        }
    }
}