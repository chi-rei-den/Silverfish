using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_003",
  "name": [
    "不稳定的传送门",
    "Unstable Portal"
  ],
  "text": [
    "随机将一张随从牌置入你的手牌。该牌的法力值消耗减少（3）点。",
    "Add a random minion to your hand. It costs (3) less."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1929
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_003 : SimTemplate //Unstable Portal
    {
        //    Add a random minion to your hand. It costs (3) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay, true);
        }
    }
}