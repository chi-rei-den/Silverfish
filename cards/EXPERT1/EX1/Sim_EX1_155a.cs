

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_155a",
  "name": [
    "猛虎之怒",
    "Tiger's Fury"
  ],
  "text": [
    "+4攻击力。",
    "+4 Attack."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 468
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_155a : SimTemplate //markofnature
    {
//    +4 angriff.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 4, 0);
        }
    }
}