

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_097",
  "name": [
    "憎恶",
    "Abomination"
  ],
  "text": [
    "<b>嘲讽，亡语：</b>对所有角色造成2点伤害。",
    "<b>Taunt</b>. <b>Deathrattle:</b> Deal 2\ndamage to ALL characters."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 440
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_097 : SimTemplate //abomination
    {
//    spott/. todesröcheln:/ fügt allen charakteren 2 schaden zu.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allCharsGetDamage(2);
        }
    }
}