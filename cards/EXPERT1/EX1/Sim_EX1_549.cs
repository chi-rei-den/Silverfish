

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_549",
  "name": [
    "狂野怒火",
    "Bestial Wrath"
  ],
  "text": [
    "在本回合中，使一个友方野兽获得+2攻击力和<b>免疫</b>。",
    "Give a friendly Beast +2 Attack and <b>Immune</b> this turn."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 1,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 903
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_549 : SimTemplate //bestialwrath
    {
//    verleiht einem wildtier +2 angriff und immunität/ in diesem zug.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetTempBuff(target, 2, 0);
            target.immune = true;
        }
    }
}