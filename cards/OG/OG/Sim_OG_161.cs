using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_161",
  "name": [
    "腐化先知",
    "Corrupted Seer"
  ],
  "text": [
    "<b>战吼：</b>对所有非鱼人随从造成2点伤害。",
    "<b>Battlecry:</b> Deal 2 damage to all non-Murloc minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38545
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_161 : SimTemplate //* Corrupted Seer
    {
        //Battlecry: Deal 2 damage to all non-Murloc minions.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            foreach (var m in p.ownMinions)
            {
                if (m.handcard.card.Race != Race.MURLOC)
                {
                    p.minionGetDamageOrHeal(m, 2);
                }
            }

            foreach (var m in p.enemyMinions)
            {
                if (m.handcard.card.Race != Race.MURLOC)
                {
                    p.minionGetDamageOrHeal(m, 2);
                }
            }
        }
    }
}