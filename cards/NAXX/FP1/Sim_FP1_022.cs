using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_022",
  "name": [
    "空灵召唤者",
    "Voidcaller"
  ],
  "text": [
    "<b>亡语：</b>\n随机将一张恶魔牌从你的手牌置入战场。",
    "<b>Deathrattle:</b> Put a random Demon from your hand into the battlefield."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1806
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_022 : SimTemplate //* voidcaller
	{
        //Deathrattle: Put a random Demon from your hand into the battlefield.
        SimCard c = CardIds.Collectible.Warlock.Felguard;//felguard

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                List<Handmanager.Handcard> temp = new List<Handmanager.Handcard>();
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.Race == Race.DEMON)
                    {
                        temp.Add(hc);
                    }
                }

                temp.Sort((x, y) => x.card.Attack.CompareTo(y.card.Attack));

                foreach (Handmanager.Handcard mnn in temp)
                {
                    p.callKid(mnn.card, p.ownMinions.Count, true, false);
                    p.removeCard(mnn);
                    break;
                }
            }
            else
            {
                if (p.enemyAnzCards >= 1)
                {
                    p.callKid(c, p.enemyMinions.Count, false, false);
                }
            }
        }
	}
}