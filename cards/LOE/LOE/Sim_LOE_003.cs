using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_003",
  "name": [
    "虚灵巫师",
    "Ethereal Conjurer"
  ],
  "text": [
    "<b>战吼：\n发现</b>一张法术牌。",
    "<b>Battlecry: Discover</b> a spell."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2875
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_003 : SimTemplate //* Ethereal Conjurer
    {
        //Battlecry: Discover a spell.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIds.NonCollectible.Neutral.TheCoin, own.own, true);
        }
    }
}