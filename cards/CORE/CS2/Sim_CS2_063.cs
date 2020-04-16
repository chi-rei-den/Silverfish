using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_063",
  "name": [
    "腐蚀术",
    "Corruption"
  ],
  "text": [
    "选择一个敌方随从，在你的回合开始时，消灭该随从。",
    "Choose an enemy minion. At the start of your turn, destroy it."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 982
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_063 : SimTemplate //corruption
	{

//    wählt einen feindlichen diener aus. vernichtet ihn zu beginn eures zuges.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            //if ownplay == true -> destroyOnOwnturnstart =true   else  destroyonenemyturnstart
            target.destroyOnOwnTurnStart = target.destroyOnOwnTurnStart || ownplay;
            target.destroyOnEnemyTurnStart = target.destroyOnEnemyTurnStart || !ownplay;
            
		}

	}
}