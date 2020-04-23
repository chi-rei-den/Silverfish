

/* _BEGIN_TEMPLATE_
{
  "id": "OG_102",
  "name": [
    "黑暗低语者",
    "Darkspeaker"
  ],
  "text": [
    "<b>战吼：</b>与另一个友方随从交换属性值。",
    "<b>Battlecry:</b> Swap stats with a friendly minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38436
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_102 : SimTemplate //* Darkspeaker
    {
        //Battlecry: Swap stats with a friendly minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null)
            {
                return;
            }

            var tmpHp = target.Hp;
            var tmpMHp = target.maxHp;
            var tmpAngr = target.Angr;

            target.Hp = own.Hp;
            target.maxHp = own.maxHp;
            target.Angr = own.Angr;

            own.Hp = tmpHp;
            own.maxHp = tmpMHp;
            own.Angr = tmpAngr;
        }
    }
}