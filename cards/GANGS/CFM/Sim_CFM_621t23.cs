using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t23",
  "name": [
    "暗影之油",
    "Shadow Oil"
  ],
  "text": [
    "随机将两张恶魔牌置入你的手牌。",
    "Add 2 random Demons to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41619
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t23 : SimTemplate //* Shadow Oil
    {
        // Add 2 random Demons to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Warlock.MalchezaarsImp, ownplay, true);
            p.drawACard(CardIds.NonCollectible.Neutral.Kazakus_KabalDemon1, ownplay, true);
        }
    }
}