using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t21",
  "name": [
    "神秘羊毛",
    "Mystic Wool"
  ],
  "text": [
    "随机使一个敌方随从变形成为1/1的绵羊。",
    "Transform a random enemy minion into a 1/1 Sheep."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41617
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t21 : SimTemplate
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target = ownplay ? p.searchRandomMinion(p.enemyMinions, SearchMode.LowAttack) : p.searchRandomMinion(p.ownMinions, SearchMode.LowAttack);
            if (target != null)
            {
                p.minionTransform(target, CardIds.NonCollectible.Neutral.Kazakus_Sheep);
            }
        }
    }
}