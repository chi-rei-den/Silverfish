using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_080e",
  "name": [
    "枯叶草毒素",
    "Fadeleaf Toxin"
  ],
  "text": [
    "直到你的下个回合，使一个友方随从获得<b>潜行</b>。",
    "Give a friendly minion <b>Stealth</b> until your next turn."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "OG",
  "collectible": null,
  "dbfId": 38942
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_080e : SimCard //* Fadeleaf Toxin
	{
		//Give a friendly minion Stealth until your next turn.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.stealth = true;
            target.conceal = true;
        }
    }
}