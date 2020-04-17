using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_605",
  "name": [
    "龙人侦测者",
    "Drakonid Operative"
  ],
  "text": [
    "<b>战吼：</b>\n如果你的手牌中有龙牌，便<b>发现</b>你对手牌库中一张牌的复制。",
    "[x]<b>Battlecry:</b> If you're holding\na Dragon, <b>Discover</b> a\ncopy of a card in your\nopponent's deck."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40378
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_605 : SimCard //* Drakonid Operative
	{
		// Battlecry: If you're holding a Dragon, Discover a card in your opponent's deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                bool dragonInHand = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON)
                    {
                        dragonInHand = true;
                        break;
                    }
                }
                if (dragonInHand)
                {
                    p.drawACard(CardDB.cardName.enchantedraven, m.own, true);
                }
            }
            else
            {
                if (p.enemyAnzCards >= 2)
                {
                    p.drawACard(CardDB.cardName.drakonidcrusher, m.own, true);
                }
            }
        }
    }
}