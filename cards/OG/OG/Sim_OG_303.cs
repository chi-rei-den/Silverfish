using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_303",
  "name": [
    "邪教女巫",
    "Cult Sorcerer"
  ],
  "text": [
    "<b>法术伤害+1</b>\n在你施放一个法术后，使你的克苏恩获得+1/+1<i>（无论它在哪里）。</i>",
    "[x]<b><b>Spell Damage</b> +1</b>\nAfter you cast a spell,\ngive your C'Thun +1/+1\n<i>(wherever it is).</i>"
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38900
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_303 : SimTemplate //* Cult Sorcerer
	{
		//Spell Damage +1. After you cast a spell, give your C'Thun +1/+1 (wherever it is).
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.type == Chireiden.Silverfish.SimCardtype.SPELL) p.cthunGetBuffed(1, 1, 0);
        }
		
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.spellpower++;
            else p.enemyspellpower++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower--;
            else p.enemyspellpower--;
        }
	}
}