

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_903",
  "name": [
    "血色狂欢者",
    "Sanguine Reveler"
  ],
  "text": [
    "<b>战吼：</b>消灭一个友方随从，并获得+2/+2。",
    "<b>Battlecry:</b> Destroy a friendly minion and gain +2/+2."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45321
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_903 : SimTemplate //* Sanguine Reveler
    {
        // Battlecry: Destroy a friendly minion and gain +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDestroyed(target);
                p.minionGetBuffed(own, 2, 2);
            }
        }
    }
}