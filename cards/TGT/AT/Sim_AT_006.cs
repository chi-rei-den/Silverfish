

/* _BEGIN_TEMPLATE_
{
  "id": "AT_006",
  "name": [
    "达拉然铁骑士",
    "Dalaran Aspirant"
  ],
  "text": [
    "<b>激励：</b>获得<b>法术伤害+1</b>。",
    "<b>Inspire:</b> Gain <b>Spell Damage +1</b>."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2549
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_006 : SimTemplate //* Dalaran Aspirant
    {
        //Inspire: Gain Spell Damage +1.

        public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own)
            {
                m.spellpower++;
                if (m.own)
                {
                    p.spellpower++;
                }
                else
                {
                    p.enemyspellpower++;
                }
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower -= m.spellpower;
            }
            else
            {
                p.enemyspellpower -= m.spellpower;
            }
        }
    }
}