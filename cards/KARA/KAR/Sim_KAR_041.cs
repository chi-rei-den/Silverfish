

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_041",
  "name": [
    "沟渠潜伏者",
    "Moat Lurker"
  ],
  "text": [
    "<b>战吼：</b>消灭一个随从。<b>亡语：</b>再次召唤被消灭的随从。",
    "<b>Battlecry:</b> Destroy a minion. <b>Deathrattle:</b> Resummon it."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39465
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_041 : SimTemplate //* Moat Lurker
    {
        //Battlecry: Destroy a minion. Deathrattle: Resummon it.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.LurkersDB.Add(own.entitiyID, new IDEnumOwner {IDEnum = target.handcard.card.CardId, own = target.own});
                p.minionGetDestroyed(target);
            }
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.LurkersDB.ContainsKey(m.entitiyID))
            {
                var own = p.LurkersDB[m.entitiyID].own;
                var pos = own ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(p.LurkersDB[m.entitiyID].IDEnum, pos, own);
            }
        }
    }
}