

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_017",
  "name": [
    "奥达曼守护者",
    "Keeper of Uldaman"
  ],
  "text": [
    "<b>战吼：</b>\n将一个随从的攻击力和生命值变为3。",
    "<b>Battlecry:</b> Set a minion's Attack and Health to 3."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2889
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_017 : SimTemplate //* Keeper of Uldaman
    {
        //Battlecry: Set a minion's Attack and Health to 3.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionSetAngrToX(target, 3);
                p.minionSetLifetoX(target, 3);
            }
        }
    }
}