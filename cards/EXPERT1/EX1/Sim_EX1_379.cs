

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_379",
  "name": [
    "忏悔",
    "Repentance"
  ],
  "text": [
    "<b>奥秘：</b>\n在你的对手使用一张随从牌后，使该随从的生命值降为1。",
    "<b>Secret:</b> After your opponent plays a minion, reduce its Health to 1."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 232
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_379 : SimTemplate //repentance
    {
//    geheimnis:/ wenn euer gegner einen diener ausspielt, wird dessen leben auf 1 verringert.

        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            target.Hp = 1;
            target.maxHp = 1;
            target.wounded = false;
        }
    }
}