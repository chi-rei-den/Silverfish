

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_257",
  "name": [
    "唤尸者",
    "Corpse Raiser"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得“<b>亡语：</b>再次召唤该随从。”",
    "[x]<b>Battlecry:</b> Give a friendly\nminion \"<b>Deathrattle:</b>\n  Resummon this minion.\""
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42909
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_257 : SimTemplate //* Corpse Raiser
    {
        // Battlecry: Give a friendly minion "Deathrattle: Resummon this minion."

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                target.ancestralspirit++;
            }
        }
    }
}