

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_612",
  "name": [
    "肯瑞托法师",
    "Kirin Tor Mage"
  ],
  "text": [
    "<b>战吼：</b>\n在本回合中，你使用的下一个<b>奥秘</b>的法力值消耗为（0）点。",
    "[x]<b>Battlecry:</b> The next <b>Secret</b>\nyou play this turn costs (0)."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 748
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_612 : SimTemplate //kirintormage
    {
//    kampfschrei:/ das nächste geheimnis/, das ihr in diesem zug ausspielt, kostet (0).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.nextSecretThisTurnCost0 = true;
            }
        }
    }
}