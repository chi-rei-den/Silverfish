using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_085",
  "name": [
    "精神控制技师",
    "Mind Control Tech"
  ],
  "text": [
    "<b>战吼：</b>如果你的对手拥有4个或者更多随从，随机获得其中一个的控制权。",
    "[x]<b>Battlecry:</b> If your opponent\nhas 4 or more minions, take\n control of one at random."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "HOF",
  "collectible": true,
  "dbfId": 734
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_085 : SimTemplate //mindcontroltech
	{
        //todo list
//    kampfschrei:/ falls euer gegner mind. 4 diener hat, übernehmt zufällig die kontrolle über einen davon.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.enemyMinions.Count >= 4)
                {
                    List<Minion> temp = new List<Minion>(p.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//we take the weekest
                    Minion targett;
                    targett = temp[0];
                    if (targett.taunt && temp.Count >= 2 && !temp[1].taunt) targett = temp[1];
                    p.minionGetControlled(targett, true, false);

                }
            }
            else
            {
                if (p.ownMinions.Count >= 4)
                {
                    List<Minion> temp = new List<Minion>(p.ownMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//we take the weekest
                    Minion targett;
                    targett = temp[0];
                    if (targett.taunt && temp.Count >= 2 && !temp[1].taunt) targett = temp[1];
                    p.minionGetControlled(targett, false, false);

                }
            }
		}

	}

}