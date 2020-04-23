

/* _BEGIN_TEMPLATE_
{
  "id": "OG_254",
  "name": [
    "奥秘吞噬者",
    "Eater of Secrets"
  ],
  "text": [
    "<b>战吼：</b>摧毁所有敌方<b>奥秘</b>。每摧毁一个，便获得+1/+1。",
    "<b>Battlecry:</b> Destroy all enemy <b>Secrets</b>. Gain +1/+1 for each."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38792
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_254 : SimTemplate //* Eater of Secrets
    {
        //Destroy all enemy Secrets. Gain +1/+1 for each.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var buff = own.own ? p.enemySecretList.Count : p.ownSecretsIDList.Count;
            p.minionGetBuffed(own, buff, buff);
            if (own.own)
            {
                p.enemySecretList.Clear();
            }
            else
            {
                p.ownSecretsIDList.Clear();
            }
        }
    }
}