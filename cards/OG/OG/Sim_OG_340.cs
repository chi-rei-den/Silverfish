

/* _BEGIN_TEMPLATE_
{
  "id": "OG_340",
  "name": [
    "深渊滑行者索苟斯",
    "Soggoth the Slitherer"
  ],
  "text": [
    "<b>嘲讽</b>\n无法成为法术或英雄技能的目标。",
    "<b>Taunt</b>\nCan't be targeted by spells or Hero Powers."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 39119
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_340 : SimTemplate //* Soggoth the Slitherer
    {
        //Taunt. Can't be targeted by spells or Hero Powers.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}