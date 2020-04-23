using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_029",
  "name": [
    "宝石甲虫",
    "Jeweled Scarab"
  ],
  "text": [
    "<b>战吼：发现</b>一张\n法力值消耗为（3）的卡牌。",
    "<b>Battlecry: Discover</b> a\n3-Cost card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2901
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_029 : SimTemplate //* Jeweled Scarab
    {
        //Battlecry: Discover a (3)-Cost card.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Neutral.SpiderTank, own.own, true);
        }
    }
}