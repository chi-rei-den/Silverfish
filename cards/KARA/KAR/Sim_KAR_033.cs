using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_033",
  "name": [
    "书卷之龙",
    "Book Wyrm"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，则消灭一个攻击力小于或等于3的敌方随从。",
    "<b>Battlecry:</b> If you're holding a Dragon, destroy an enemy minion with 3 or less Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39210
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_033 : SimTemplate //* Book Wyrm
    {
        //Battlecry: If you're holding a Dragon, destroy an enemy minion with 3 Attack or less.

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
                    if (target != null)
                    {
                        p.minionGetDestroyed(target);
                    }
                }
            }
            else
            {
                if (p.enemyAnzCards >= 2)
                {
                    if (target != null)
                    {
                        p.minionGetDestroyed(target);
                    }
                }
            }
        }
    }
}