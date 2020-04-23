

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_954",
  "name": [
    "最后的水晶龙",
    "The Last Kaleidosaur"
  ],
  "text": [
    "<b>任务：</b>对你的随从施放6个法术。\n<b>奖励：</b>嘉沃顿。",
    "<b>Quest:</b> Cast 6 spells\non your minions.\n<b>Reward:</b> Galvadon."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41868
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_954 : SimTemplate //* The Last Kaleidosaur
    {
        //Quest: Cast 6 spells on your minions. Reward: Galvadon.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2)
            {
                p.evaluatePenality -= 30;
            }
        }
    }
}