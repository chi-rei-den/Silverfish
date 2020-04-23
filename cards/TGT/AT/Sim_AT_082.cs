

/* _BEGIN_TEMPLATE_
{
  "id": "AT_082",
  "name": [
    "低阶侍从",
    "Lowly Squire"
  ],
  "text": [
    "<b>激励：</b>\n获得+1攻击力。",
    "<b>Inspire:</b> Gain +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2486
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_082 : SimTemplate //* Lowly Squire
    {
        //Inspire: Gain +1 Attack.

        public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own)
            {
                p.minionGetBuffed(m, 1, 0);
            }
        }
    }
}