

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_466",
  "name": [
    "萨隆苦囚",
    "Saronite Chain Gang"
  ],
  "text": [
    "<b>嘲讽</b>\n<b>战吼：</b>召唤另一个萨隆苦囚。",
    "[x]<b>Taunt</b>\n<b>Battlecry:</b> Summon another\nSaronite Chain Gang."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42395
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_466 : SimTemplate //* Saronite Chain Gang
    {
        // Taunt Battlecry: Summon another Saronite Chain Gang.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(m.handcard.card, m.zonepos, m.own);
        }
    }
}