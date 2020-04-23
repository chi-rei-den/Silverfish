

/* _BEGIN_TEMPLATE_
{
  "id": "OG_293",
  "name": [
    "黑暗鸦人",
    "Dark Arakkoa"
  ],
  "text": [
    "<b>嘲讽</b>，<b>战吼：</b>使你的克苏恩获得+3/+3<i>（无论它在哪里）。</i>",
    "[x]<b>Taunt</b>\n<b>Battlecry:</b> Give your C'Thun\n+3/+3 <i>(wherever it is).</i>"
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38882
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_293 : SimTemplate //* Dark Arakkoa
    {
        //Taunt. Battlecry: Give your C'Thun +3/+3 (wherever it is).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.cthunGetBuffed(3, 3, 0);
            }
        }
    }
}