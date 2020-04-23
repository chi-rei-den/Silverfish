

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_005",
  "name": [
    "纳克萨玛斯之影",
    "Shade of Naxxramas"
  ],
  "text": [
    "<b>潜行。</b>在你的回合开始时，获得+1/+1。",
    "<b>Stealth.</b> At the start of your turn, gain +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1784
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_005 : SimTemplate //shadeofnaxxramas
    {
//    verstohlenheit/. erhält zu beginn eures zuges +1/+1.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }
    }
}