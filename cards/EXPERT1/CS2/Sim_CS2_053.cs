using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_053",
  "name": [
    "视界术",
    "Far Sight"
  ],
  "text": [
    "抽一张牌，该牌的法力值消耗减少（3）点。",
    "Draw a card. That card costs (3) less."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 818
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_053 : SimTemplate //far sight
    {
        //todo: bonus for it?
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay);
        }
    }
}