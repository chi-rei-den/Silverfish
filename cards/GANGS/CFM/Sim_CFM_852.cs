using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_852",
  "name": [
    "玉莲帮密探",
    "Lotus Agents"
  ],
  "text": [
    "<b>战吼：</b><b>发现</b>一张德鲁伊、潜行者或萨满祭司卡牌。",
    "<b>Battlecry:</b> <b>Discover</b> a Druid, Rogue, or Shaman card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40742
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_852 : SimTemplate //* Lotus Agents
	{
		// Battlecry: Discover a Druid, Rogue or Shaman card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.shieldbearer, m.own, true);
        }
    }
}