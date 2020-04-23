

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_018",
  "name": [
    "复制",
    "Duplicate"
  ],
  "text": [
    "<b>奥秘：</b>当一个友方随从死亡时，将两张该随从的复制置入你的手牌。",
    "<b>Secret:</b> When a friendly minion dies, put 2 copies of it into your hand."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1801
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_018 : SimTemplate //duplicate
    {
        //todo secret
//    geheimnis:/ wenn ein befreundeter diener stirbt, erhaltet ihr 2 kopien dieses dieners auf eure hand.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            if (ownplay)
            {
                p.drawACard(p.revivingOwnMinion, ownplay, true);
                p.drawACard(p.revivingOwnMinion, ownplay, true);
            }
            else
            {
                p.drawACard(p.revivingEnemyMinion, ownplay, true);
                p.drawACard(p.revivingEnemyMinion, ownplay, true);
            }
        }
    }
}