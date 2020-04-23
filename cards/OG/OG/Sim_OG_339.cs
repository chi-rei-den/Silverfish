

/* _BEGIN_TEMPLATE_
{
  "id": "OG_339",
  "name": [
    "斯克拉姆狂热者",
    "Skeram Cultist"
  ],
  "text": [
    "<b>战吼：</b>\n使你的克苏恩\n获得+2/+2<i>（无论它在哪里）。</i>",
    "<b>Battlecry:</b> Give your C'Thun +2/+2 <i>(wherever it is).</i>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 39118
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_339 : SimTemplate //* Skeram Cultist
    {
        //Battlecry: Give your C'Thun +2/+2 (wherever it is).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.cthunGetBuffed(2, 2, 0);
            }
        }
    }
}