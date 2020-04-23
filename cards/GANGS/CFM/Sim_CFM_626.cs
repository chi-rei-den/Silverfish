

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_626",
  "name": [
    "暗金教鸦人祭司",
    "Kabal Talonpriest"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得+3生命值。",
    "<b>Battlecry:</b> Give a friendly minion +3 Health."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40432
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_626 : SimTemplate //* Kabal Talonpriest
    {
        // Battlecry: Give a friendly minion +3 Health.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetBuffed(target, 0, 3);
            }
        }
    }
}