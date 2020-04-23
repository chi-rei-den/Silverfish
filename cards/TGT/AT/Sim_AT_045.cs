

/* _BEGIN_TEMPLATE_
{
  "id": "AT_045",
  "name": [
    "艾维娜",
    "Aviana"
  ],
  "text": [
    "你的随从牌的法力值消耗为（1）点。",
    "Your minions cost (1)."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2796
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_045 : SimTemplate //* Aviana
    {
        //Your minions cost (1).

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnAviana++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnAviana--;
            }
        }
    }
}