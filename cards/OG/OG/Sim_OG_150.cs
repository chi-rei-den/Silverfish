

/* _BEGIN_TEMPLATE_
{
  "id": "OG_150",
  "name": [
    "畸变狂战士",
    "Aberrant Berserker"
  ],
  "text": [
    "受伤时具有+2攻\n击力。",
    "Has +2 Attack while damaged."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38531
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_150 : SimTemplate //* Aberrant Berserker
    {
        //Enrage: +2 Attack.

        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr += 2;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr -= 2;
        }
    }
}