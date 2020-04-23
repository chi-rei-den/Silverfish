

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_917t1",
  "name": [
    "恐龙学",
    "Dinomancy"
  ],
  "text": [
    "<b>英雄技能</b>\n使一个野兽获得+2/+2。",
    "<b>Hero Power</b>\nGive a Beast +2/+2."
  ],
  "cardClass": "HUNTER",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41362
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_917t1 : SimTemplate //* Dinomancy
    {
        //Hero Power: Give a Beast +2/+2.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 2);
        }
    }
}