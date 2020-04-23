

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_023",
  "name": [
    "精灵龙",
    "Faerie Dragon"
  ],
  "text": [
    "无法成为法术或英雄技能的目标。",
    "Can't be targeted by spells or Hero Powers."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 609
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_023 : SimTemplate //faeriedragon
    {
//    kann nicht als ziel von zaubern oder heldenfähigkeiten gewählt werden.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}