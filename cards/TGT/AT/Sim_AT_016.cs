

/* _BEGIN_TEMPLATE_
{
  "id": "AT_016",
  "name": [
    "迷乱",
    "Confuse"
  ],
  "text": [
    "将所有随从的攻击力和生命值\n互换。",
    "Swap the Attack and Health of all minions."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2564
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_016 : SimTemplate //* Confuse
    {
        //Swap the Attack and Health of all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (var m in p.ownMinions)
            {
                p.minionSwapAngrAndHP(m);
            }

            foreach (var m in p.enemyMinions)
            {
                p.minionSwapAngrAndHP(m);
            }
        }
    }
}