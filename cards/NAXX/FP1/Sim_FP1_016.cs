

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_016",
  "name": [
    "哀嚎的灵魂",
    "Wailing Soul"
  ],
  "text": [
    "<b>战吼：沉默</b>你的其他随从。",
    "<b>Battlecry: Silence</b> your other minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1799
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_016 : SimTemplate //* Wailing Soul
    {
        // Battlecry: Silence your other minions.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.entitiyID != own.entitiyID)
                {
                    p.minionGetSilenced(m);
                }
            }
        }
    }
}