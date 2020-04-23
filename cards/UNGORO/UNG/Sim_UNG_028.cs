

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_028",
  "name": [
    "打开时空之门",
    "Open the Waygate"
  ],
  "text": [
    "<b>任务：</b>施放6个你的套牌之外的\n法术。\n <b>奖励：</b>时空扭曲。",
    "[x]<b>Quest:</b> Cast 6 spells that\ndidn't start in your deck.\n<b>Reward:</b> Time Warp."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41168
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_028 : SimTemplate //* Open the Waygate
    {
        //Quest: Cast 6 spells that didn't start in your deck. Reward: Time Warp.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2)
            {
                p.evaluatePenality -= 30;
            }
        }
    }
}