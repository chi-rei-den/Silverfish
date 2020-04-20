using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_101",
  "name": [
    "变形神龟",
    "Shellshifter"
  ],
  "text": [
    "<b>抉择：</b>将该随从变形成为5/3并具有<b>潜行</b>；或者将该随从变形成为3/5并具有<b>嘲讽</b>。",
    "[x]<b>Choose One - </b>Transform\ninto a 5/3 with <b>Stealth</b>;\nor a 3/5 with <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 40973
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_101 : SimTemplate //* Shellshifter
	{
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, CardIds.NonCollectible.Druid.Shellshifter_ShellshifterToken3);
            }
            else
            {
                if (choice == 1)
                {
                    p.minionTransform(own, CardIds.NonCollectible.Druid.Shellshifter_ShellshifterToken1);
                }
                else if (choice == 2)
                {
                    p.minionTransform(own, CardIds.NonCollectible.Druid.Shellshifter_ShellshifterToken2);
                }
            }
		}
	}
}