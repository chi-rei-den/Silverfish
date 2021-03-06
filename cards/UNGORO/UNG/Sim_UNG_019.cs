

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_019",
  "name": [
    "空气元素",
    "Air Elemental"
  ],
  "text": [
    "无法成为法术或英雄技能的目标。",
    "Can't be targeted by spells or Hero Powers."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41152
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_019 : SimTemplate //* Air Elemental
    {
        //Can't be targeted by spells or Hero Powers.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}