

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_656",
  "name": [
    "街头调查员",
    "Streetwise Investigator"
  ],
  "text": [
    "<b>战吼：</b>使所有敌方随从失去<b>潜行</b>。",
    "<b>Battlecry:</b> Enemy minions lose <b>Stealth</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40928
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_656 : SimTemplate //* Streetwise Investigator
    {
        // Battlecry: Enemy minions lose Stealth.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            var temp = m.own ? p.enemyMinions : p.ownMinions;
            foreach (var mnn in temp)
            {
                mnn.stealth = false;
            }
        }
    }
}