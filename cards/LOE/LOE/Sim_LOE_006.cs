using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_006",
  "name": [
    "博物馆馆长",
    "Museum Curator"
  ],
  "text": [
    "<b>战吼：\n发现</b>一张<b>亡语</b>牌。",
    "<b>Battlecry: Discover</b> a <b>Deathrattle</b> card."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2878
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_006 : SimTemplate //* Museum Curator
    {
        //Battlecry: Discover a Deathrattle card.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Neutral.LeperGnome, own.own, true);
        }
    }
}