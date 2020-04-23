

/* _BEGIN_TEMPLATE_
{
  "id": "OG_162",
  "name": [
    "克苏恩的信徒",
    "Disciple of C'Thun"
  ],
  "text": [
    "<b>战吼：</b>\n造成2点伤害。使你的克苏恩获得+2/+2<i>（无论它在哪里）。</i>",
    "<b>Battlecry:</b> Deal 2 damage. Give your C'Thun +2/+2 <i>(wherever it is)</i>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38547
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_162 : SimTemplate //* Disciple of C'Thun
    {
        //Battlecry: Deal 2 damage. Give your C'Thun +2/+2 (wherever it is)

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(target, 2);
            if (own.own)
            {
                p.cthunGetBuffed(2, 2, 0);
            }
        }
    }
}