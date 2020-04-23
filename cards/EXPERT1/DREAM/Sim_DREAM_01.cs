

/* _BEGIN_TEMPLATE_
{
  "id": "DREAM_01",
  "name": [
    "欢笑的姐妹",
    "Laughing Sister"
  ],
  "text": [
    "无法成为法术或英雄技能的目标。",
    "Can't be targeted by spells or Hero Powers."
  ],
  "cardClass": "DREAM",
  "type": "MINION",
  "cost": 3,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 340
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DREAM_01 : SimTemplate //laughingsister
    {
//    kann nicht als ziel von zaubern oder heldenfähigkeiten gewählt werden.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}