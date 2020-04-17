using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_289",
  "name": [
    "莫拉比",
    "Moorabi"
  ],
  "text": [
    "每当有其他随从被<b>冻结</b>，将一张被<b>冻结</b>随从的复制置入你的\n手牌。",
    "Whenever another minion is <b>Frozen</b>, add a copy of it to your hand."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43072
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_289: SimCard //* Moorabi
    {
        // Whenever another minion is Frozen, add a copy of it to your hand.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            p.anzMoorabi++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.anzMoorabi--;
        }
    }
}