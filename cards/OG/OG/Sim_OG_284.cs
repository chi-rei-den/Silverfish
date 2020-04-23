

/* _BEGIN_TEMPLATE_
{
  "id": "OG_284",
  "name": [
    "暮光地卜师",
    "Twilight Geomancer"
  ],
  "text": [
    "<b>嘲讽</b>，<b>战吼：</b>使你的克苏恩获得<b>嘲讽</b><i>（无论它在哪里）。</i>",
    "[x]<b>Taunt</b>\n<b>Battlecry:</b> Give your C'Thun\n<b>Taunt</b> <i>(wherever it is).</i>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38864
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_284 : SimTemplate //* Twilight Geomancer
    {
        //Taunt. Battlecry: Give your C'Thun Taunt (wherever it is).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.cthunGetBuffed(0, 0, 1);
            }
        }
    }
}