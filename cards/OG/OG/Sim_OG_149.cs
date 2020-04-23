

/* _BEGIN_TEMPLATE_
{
  "id": "OG_149",
  "name": [
    "暴虐食尸鬼",
    "Ravaging Ghoul"
  ],
  "text": [
    "<b>战吼：</b>对所有其他随从造成1点伤害。",
    "<b>Battlecry:</b> Deal 1 damage to all other minions."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38530
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_149 : SimTemplate //* Ravaging Ghoul
    {
        //Battlecry: Deal 1 damage to all other minions.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allMinionsGetDamage(1, own.entitiyID);
        }
    }
}