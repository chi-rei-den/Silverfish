using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_917",
  "name": [
    "恐龙学",
    "Dinomancy"
  ],
  "text": [
    "你的英雄技能变成“使一个野兽获得+2/+2”。",
    "Your Hero Power becomes 'Give a Beast +2/+2.'"
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41363
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_917 : SimTemplate //* Dinomancy
    {
        //Your Hero Power: becomes 'Give a Beast +2/+2.'

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Hunter.Dinomancy_DinomancyToken, ownplay); // Dinomancy
        }
    }
}