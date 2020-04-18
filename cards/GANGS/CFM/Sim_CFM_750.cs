using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_750",
  "name": [
    "唤魔者克鲁尔",
    "Krul the Unshackled"
  ],
  "text": [
    "<b>战吼：</b>如果你的牌库里没有相同的牌，则将你手牌中所有的恶魔牌置入战场。",
    "[x]<b>Battlecry:</b> If your deck has\nno duplicates, summon all\n Demons from your hand. "
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40537
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_750 : SimTemplate //* Krul the Unshackled
	{
		// Battlecry: If your deck has no duplicates, summon all Demons from your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                if (p.prozis.noDuplicates)
                {
				    if (p.ownMinions.Count < 7)
				    {
					    bool needTrigger = false;
					    foreach (Handmanager.Handcard hc in p.owncards.ToArray())
					    {
                            if ((TAG_RACE)hc.card.Race == TAG_RACE.DEMON)
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
            }
            else
            {
                if (p.enemyAnzCards > 1)
                {
                    int pos = p.enemyMinions.Count;
                    p.callKid(CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_306), pos, false); //Succubus
                    p.enemyAnzCards--;
                    p.triggerCardsChanged(false);
                    if (p.ownHeroHasDirectLethal())
                    {
                        p.enemyMinions[pos].Angr = 2;
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