

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_363",
  "name": [
    "智慧祝福",
    "Blessing of Wisdom"
  ],
  "text": [
    "选择一个随从，每当其进行攻击，便抽一张牌。",
    "Choose a minion. Whenever it attacks, draw a card."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1373
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_363 : SimTemplate //blessingofwisdom
    {
//    wählt einen diener aus. zieht jedes mal eine karte, wenn er angreift.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                target.ownBlessingOfWisdom++;
            }
            else
            {
                target.enemyBlessingOfWisdom++;
            }
        }
    }
}