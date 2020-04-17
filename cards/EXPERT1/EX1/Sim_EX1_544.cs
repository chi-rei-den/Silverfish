using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_544",
  "name": [
    "照明弹",
    "Flare"
  ],
  "text": [
    "所有随从失去<b>潜行</b>，摧毁所有敌方<b>奥秘</b>，抽一张牌。",
    "All minions lose <b>Stealth</b>. Destroy all enemy <b>Secrets</b>. Draw a card."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 896
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_544 : SimCard //flare
    {

        //    alle diener verlieren verstohlenheit/. zerstört alle feindlichen geheimnisse/. zieht eine karte.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                m.stealth = false;
            }
            foreach (Minion m in p.enemyMinions)
            {
                m.stealth = false;
            }
            if (ownplay)
            {
                p.enemySecretCount = 0;
                p.enemySecretList.Clear();
            }
            else
            {
                p.ownSecretsIDList.Clear();
            }
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
        }

    }

}