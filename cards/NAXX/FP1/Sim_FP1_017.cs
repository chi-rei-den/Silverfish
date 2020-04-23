

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_017",
  "name": [
    "尼鲁巴蛛网领主",
    "Nerub'ar Weblord"
  ],
  "text": [
    "具有<b>战吼</b>的随从法力值消耗增加(2)点。",
    "Minions with <b>Battlecry</b> cost (2) more."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1800
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_017 : SimTemplate //nerubarweblord
    {
//    diener mit kampfschrei/ kosten (2) mehr.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            p.nerubarweblord++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.nerubarweblord--;
        }
    }
}