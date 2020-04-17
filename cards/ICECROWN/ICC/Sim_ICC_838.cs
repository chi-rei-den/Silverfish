using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_838",
  "name": [
    "辛达苟萨",
    "Sindragosa"
  ],
  "text": [
    "<b>战吼：</b>召唤两个0/1的被冰封的勇士。",
    "<b>Battlecry:</b> Summon two 0/1 Frozen Champions."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43506
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_838 : SimCard //* Sindragosa
    {
        // Battlecry: Summon two 0/1 Frozen Champions.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_838t); //Frozen Champion

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(kid, own.zonepos - 1, own.own); //1st left
            p.callKid(kid, own.zonepos, own.own);
        }
    }
}