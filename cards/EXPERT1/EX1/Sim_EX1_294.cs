

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_294",
  "name": [
    "镜像实体",
    "Mirror Entity"
  ],
  "text": [
    "<b>奥秘：</b>在你的对手使用一张随从牌后，召唤一个该随从的复制。",
    "<b>Secret:</b> After your opponent plays a minion, summon a copy of it."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 195
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_294 : SimTemplate //* mirrorentity
    {
        //Secret: When your opponent plays a minion, summon a copy of it.

        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(target.handcard.card, pos, ownplay);
            if (ownplay)
            {
                if (p.ownMinions.Count >= 1 && p.ownMinions[p.ownMinions.Count - 1].name == target.handcard.card.CardId)
                {
                    var e = p.ownMinions[p.ownMinions.Count - 1].entitiyID;
                    p.ownMinions[p.ownMinions.Count - 1].setMinionToMinion(target);
                    p.ownMinions[p.ownMinions.Count - 1].entitiyID = e;
                    p.ownMinions[p.ownMinions.Count - 1].own = true;
                }
            }
            else
            {
                if (p.enemyMinions.Count >= 1 && p.enemyMinions[p.enemyMinions.Count - 1].name == target.handcard.card.CardId)
                {
                    var e = p.enemyMinions[p.enemyMinions.Count - 1].entitiyID;
                    p.enemyMinions[p.enemyMinions.Count - 1].setMinionToMinion(target);
                    p.enemyMinions[p.enemyMinions.Count - 1].entitiyID = e;
                    p.enemyMinions[p.enemyMinions.Count - 1].own = false;
                }
            }
        }
    }
}