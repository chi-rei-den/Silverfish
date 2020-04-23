

/* _BEGIN_TEMPLATE_
{
  "id": "OG_218",
  "name": [
    "血蹄勇士",
    "Bloodhoof Brave"
  ],
  "text": [
    "<b>嘲讽</b>\n受伤时具有+3攻\n击力。",
    "<b>Taunt</b>\nHas +3 Attack while damaged."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38738
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_218 : SimTemplate //* Bloodhoof Brave
    {
        //Taunt. Enrage:+3 Attack.

        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr += 3;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr -= 3;
        }
    }
}