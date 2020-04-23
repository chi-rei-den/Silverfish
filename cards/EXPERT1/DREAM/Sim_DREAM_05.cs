

/* _BEGIN_TEMPLATE_
{
  "id": "DREAM_05",
  "name": [
    "噩梦",
    "Nightmare"
  ],
  "text": [
    "使一个随从获得+5/+5，在你的下一个回合开始时，消灭该随从。",
    "Give a minion +5/+5. At the start of your next turn, destroy it."
  ],
  "cardClass": "DREAM",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 217
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DREAM_05 : SimTemplate //Nightmare
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 4, 4);
            if (ownplay)
            {
                target.destroyOnOwnTurnStart = true;
            }
            else
            {
                target.destroyOnEnemyTurnStart = true;
            }
        }
    }
}