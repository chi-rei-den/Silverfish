using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_912",
  "name": [
    "夺尸者",
    "Corpsetaker"
  ],
  "text": [
    "<b>战吼：</b>\n如果你的牌库里包含具有<b>嘲讽</b>的随从牌，则获得<b>嘲讽</b>。依此法检定是否可获得<b>圣盾</b>、<b>吸血</b>和<b>风怒</b>。",
    "[x]<b>Battlecry:</b> Gain <b>Taunt</b> if your\ndeck has a <b>Taunt</b> minion.\nRepeat for <b>Divine Shield</b>,\n<b>Lifesteal</b>, <b>Windfury</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 46102
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_912: SimCard //* Corpsetaker
    {
        // Battlecry: Gain Taunt if your deck has a Taunt minion. Repeat for Divine Shield, Lifesteal, Windfury.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.prozis.numDeckCardsByTag(GAME_TAGs.TAUNT) > 0)
                {
                    own.taunt = true;
                    p.anzOwnTaunt++;
                }
                if (p.prozis.numDeckCardsByTag(GAME_TAGs.DIVINE_SHIELD) > 0) own.divineshild = true;
                if (p.prozis.numDeckCardsByTag(GAME_TAGs.LIFESTEAL) > 0) own.lifesteal = true;
                if (p.prozis.numDeckCardsByTag(GAME_TAGs.WINDFURY) > 0) own.windfury = true;
            }
        }
    }
}