using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_236",
  "name": [
    "破冰斧",
    "Ice Breaker"
  ],
  "text": [
    "消灭所有受到该武器伤害的被<b>冻结</b>的随从。",
    "Destroy any <b>Frozen</b> minion damaged by this."
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42808
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_236 : SimTemplate //* Ice Breaker
    {
        // Destroy any Frozen minion damaged by this.
        //done in Playfield

        SimCard w = CardIds.Collectible.Shaman.IceBreaker;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.w, ownplay);
        }
    }
}