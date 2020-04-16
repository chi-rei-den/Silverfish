using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_041b",
  "name": [
    "大自然的防线",
    "Nature's Defense"
  ],
  "text": [
    "召唤5个小精灵。",
    "Summon 5 Wisps."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2177
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_041b : SimTemplate //* Dark Wispers
    {
        //   Summon 5 Wisps;

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            for (int i = 0; i < 5; i++)
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, pos, ownplay);
            }
        }
    }
}