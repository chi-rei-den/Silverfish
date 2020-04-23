using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_004",
  "name": [
    "暮光雏龙",
    "Twilight Whelp"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，便获得+2生命值。",
    "<b>Battlecry:</b> If you're holding a Dragon, gain +2 Health."
  ],
  "CardClass": "PRIEST",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2286
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_004 : SimTemplate //* Twilight Whelp
    {
        // Battlecry: If you're holding a Dragon, gain +2 Health.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                var dragonInHand = false;
                foreach (var hc in p.owncards)
                {
                    if (hc.card.Race == Race.DRAGON)
                    {
                        dragonInHand = true;
                        break;
                    }
                }

                if (dragonInHand)
                {
                    p.minionGetBuffed(m, 0, 2);
                }
            }
            else
            {
                if (p.enemyAnzCards >= 2)
                {
                    p.minionGetBuffed(m, 0, 2);
                }
            }
        }
    }
}