

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_942",
  "name": [
    "鱼人总动员",
    "Unite the Murlocs"
  ],
  "text": [
    "<b>任务：</b>召唤10个鱼人。\n<b>奖励：老鲨嘴</b>。",
    "[x]<b>Quest:</b> Summon\n10 Murlocs.\n<b>Reward:</b> Megafin."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41499
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_942 : SimTemplate //* Unite the Murlocs
    {
        //Quest: Summon 10 Murlocs. Reward: Megafin.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2)
            {
                p.evaluatePenality -= 30;
            }
        }
    }
}