

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_056",
  "name": [
    "低温静滞",
    "Cryostasis"
  ],
  "text": [
    "使一个随从获得+3/+3，并使其<b>冻结</b>。",
    "Give a minion +3/+3 and <b>Freeze</b> it."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42676
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_056 : SimTemplate //* Cryostasis
    {
        // Give a minion +3/+3 and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 3);
            p.minionGetFrozen(target);
        }
    }
}