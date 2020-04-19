using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ULD_413",
  "name": [
    "分裂战斧",
    "Splitting Axe"
  ],
  "text": [
    "<b>战吼：</b>召唤你的图腾的复制。",
    "<b>Battlecry:</b> Summon copies of your Totems."
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 4,
  "rarity": "EPIC",
  "set": "ULDUM",
  "collectible": true,
  "dbfId": 53661
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_ULD_413 : SimTemplate //* 分裂战斧 Splitting Axe
	{
		//<b>Battlecry:</b> Summon copies of your Totems.
		//<b>战吼：</b>召唤你的图腾的复制。
		Chireiden.Silverfish.SimCard weapon = CardIds.Collectible.Shaman.SplittingAxe;
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			p.equipWeapon(weapon, ownplay);
			List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
			List<Minion> CopiesMinion = new List<Minion>();
			foreach (Minion t in temp)
				if ((Race)t.handcard.card.Race == Race.TOTEM)
					CopiesMinion.Add(t);
			foreach (Minion t in CopiesMinion)
			{
				int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
				if (pos < 7)
				{
					p.callKid(t.handcard.card, pos, ownplay);
					if(ownplay) p.ownMinions[pos].setMinionToMinion(t);	
					else p.enemyMinions[pos].setMinionToMinion(t);
				}
			}
		}
	}
}