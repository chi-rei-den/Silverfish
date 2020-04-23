

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_227",
  "name": [
    "风险投资公司雇佣兵",
    "Venture Co. Mercenary"
  ],
  "text": [
    "你的随从牌的法力值消耗增加（3）点。",
    "Your minions cost (3) more."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1122
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_227 : SimTemplate //* Venture Co. Mercenary
    {
        //Your minions cost (3) more.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownMinionsCostMore += 3;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownMinionsCostMore -= 3;
            }
        }
    }
}