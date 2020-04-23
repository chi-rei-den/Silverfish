

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t7",
  "name": [
    "闪电之速",
    "Lightning Speed"
  ],
  "text": [
    "<b>风怒</b>",
    "<b>Windfury</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41062
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_999t7 : SimTemplate //* Lightning Speed
    {
        //Windfury

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetWindfurry(target);
        }
    }
}