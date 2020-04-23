

/* _BEGIN_TEMPLATE_
{
  "id": "OG_310",
  "name": [
    "夜色镇执法官",
    "Steward of Darkshire"
  ],
  "text": [
    "每当你召唤一个生命值为1的随从，便使其获得<b>圣盾</b>。",
    "Whenever you summon a 1-Health minion, give it <b>Divine Shield</b>."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38911
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_310 : SimTemplate //* Steward of Darkshire
    {
        //Whenever you summon a 1-Health minion, give it Divine Shield.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (summonedMinion.Hp == 1 && m.own == summonedMinion.own && m.entitiyID != summonedMinion.entitiyID)
            {
                summonedMinion.divineshild = true;
            }
        }
    }
}