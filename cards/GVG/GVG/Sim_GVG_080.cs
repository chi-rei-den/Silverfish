using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_080",
  "name": [
    "尖牙德鲁伊",
    "Druid of the Fang"
  ],
  "text": [
    "<b>战吼：</b>如果你控制任何野兽，将该随从变形成为7/7。",
    "<b>Battlecry:</b> If you have a Beast, transform this minion into a 7/7."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2048
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_080 : SimTemplate //* Druid of the Fang
    {
        //   Battlecry:If you have a Beast, transform this minion into a 7/7.
        CardDB.Card betterguy = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_080t);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            bool hasbeast = false;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                {
                    hasbeast = true;
                    break;
                }
            }
            if(hasbeast) p.minionTransform(own, betterguy);
        }
    }
}