using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_098",
  "name": [
    "墓穴潜伏者",
    "Tomb Lurker"
  ],
  "text": [
    "<b>战吼：</b>随机将一个在本局对战中死亡并具有<b>亡语</b>的随从置入你的手牌。",
    "[x]<b>Battlecry:</b> Add a random\n<b>Deathrattle</b> minion that died\nthis game to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42781
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_098: SimTemplate //* Tomb Lurker
    {
        // Battlecry: Add a random Deathrattle minion that died this game to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            var temp = (own.own) ? Probabilitymaker.Instance.ownCardsOut : Probabilitymaker.Instance.enemyCardsOut;
            SimCard c;
            bool found = false;
            foreach (var gi in temp)
            {
                c = (gi.Key);
                if (c.Deathrattle)
                {
                    p.drawACard(c.CardId, own.own, true);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                foreach (var gi in p.diedMinions)
                {
                    if (gi.own == own.own)
                    {
                        c = (gi.cardid);
                        if (c.Deathrattle)
                        {
                            p.drawACard(c.CardId, own.own, true);
                            break;
                        }
                    }
                }
            }
        }
    }
}