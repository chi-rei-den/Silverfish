

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_008",
  "name": [
    "鬼灵骑士",
    "Spectral Knight"
  ],
  "text": [
    "无法成为法术或英雄技能的目标。",
    "Can't be targeted by spells or Hero Powers."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1789
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_008 : SimTemplate //spectralknight
    {
//    kann nicht als ziel von zaubern oder heldenfähigkeiten gewählt werden.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}