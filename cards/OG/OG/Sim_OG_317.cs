using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_317",
  "name": [
    "黑龙领主死亡之翼",
    "Deathwing, Dragonlord"
  ],
  "text": [
    "<b>亡语：</b>将你手牌中所有的龙牌置入战场。",
    "<b>Deathrattle:</b> Put all Dragons from your hand into the battlefield."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38943
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_317 : SimTemplate //* Deathwing, Dragonlord
	{
		//Deathrattle: Put all Dragons from your hand into the battlefield.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
				if (p.ownMinions.Count < 7)
				{
					bool needTrigger = false;
					foreach (Handmanager.Handcard hc in p.owncards.ToArray())
					{
						if ((Race)hc.card.Race == Race.DRAGON)
						{
							p.callKid(hc.card, p.ownMinions.Count, true);
							p.removeCard(hc);
							needTrigger = true;
							if (p.ownMinions.Count > 6) break;
						}
					}
					if (needTrigger) p.triggerCardsChanged(true);
				}
            }
            else
            {
				if (p.enemyAnzCards > 1)
                {
                    int pos = p.enemyMinions.Count;
                    p.callKid(CardIds.Collectible.Neutral.Alexstrasza, pos, false); //Alexstrasza
					p.enemyAnzCards--;
                    p.triggerCardsChanged(false);
                    if (p.ownHeroHasDirectLethal())
                    {
                        p.enemyMinions[pos].Angr = 3;
                        if (p.ownHeroHasDirectLethal())
                        {
                            p.enemyMinions[pos].Angr = 0;
                        }
                    }
				}
            }
        }
	}
}
