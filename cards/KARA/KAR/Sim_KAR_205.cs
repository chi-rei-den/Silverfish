

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_205",
  "name": [
    "镀银魔像",
    "Silverware Golem"
  ],
  "text": [
    "如果你弃掉了这张随从牌，则会召唤它。",
    "If you discard this minion, summon it."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39380
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_205 : SimTemplate //* Silverware Golem
    {
        //If you discard this minion, summon it.

        public override bool onCardDicscard(Playfield p, Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (checkBonus)
            {
                return true;
            }

            if (own != null)
            {
                return false;
            }

            var ownplay = true;
            var temp = ownplay ? p.ownMinions : p.enemyMinions;
            p.callKid(hc.card, temp.Count, ownplay, false);
            var m = temp[temp.Count - 1];
            if (m.name == hc.card.CardId && m.playedThisTurn)
            {
                m.entitiyID = hc.entity;
                m.Angr += hc.addattack;
                m.Hp += hc.addHp;
            }

            return true;
        }
    }
}