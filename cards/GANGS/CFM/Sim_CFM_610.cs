using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_610",
  "name": [
    "魔瘾结晶者",
    "Crystalweaver"
  ],
  "text": [
    "<b>战吼：</b>使你的所有恶魔获得+1/+1。",
    "<b>Battlecry:</b> Give your Demons +1/+1."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40391
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_610 : SimTemplate //* Crystalweaver
    {
        // Battlecry: Give your Demons +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            var temp = m.own ? p.ownMinions : p.enemyMinions;
            foreach (var mnn in temp)
            {
                if (mnn.handcard.card.Race == Race.DEMON && mnn.entitiyID != m.entitiyID)
                {
                    p.minionGetBuffed(mnn, 1, 1);
                }
            }
        }
    }
}