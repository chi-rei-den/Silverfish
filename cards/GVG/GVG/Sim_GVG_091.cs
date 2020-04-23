

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_091",
  "name": [
    "施法者克星X-21",
    "Arcane Nullifier X-21"
  ],
  "text": [
    "<b>嘲讽，</b>无法成为法术或英雄技能的目标。",
    "<b>Taunt</b>\nCan't be targeted by spells or Hero Powers."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2059
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_091 : SimTemplate //Arcane Nullifier X-21
    {
        //   Taunt  can't be targeted by spells or Hero Powers.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}