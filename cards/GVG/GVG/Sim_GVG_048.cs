using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_048",
  "name": [
    "金刚刃牙兽",
    "Metaltooth Leaper"
  ],
  "text": [
    "<b>战吼：</b>使你的其他机械获得+2攻击力。",
    "<b>Battlecry:</b> Give your other Mechs +2 Attack."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2016
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_048 : SimTemplate //* Metaltooth Leaper
    {
        //Battlecry: Give your other Mechs +2 Attack.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.entitiyID == own.entitiyID)
                {
                    continue;
                }

                if (m.handcard.card.Race == Race.MECHANICAL)
                {
                    p.minionGetBuffed(m, 2, 0);
                }
            }
        }
    }
}