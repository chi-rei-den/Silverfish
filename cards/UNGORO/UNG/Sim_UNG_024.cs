using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_024",
  "name": [
    "法术共鸣",
    "Mana Bind"
  ],
  "text": [
    "<b>奥秘：</b>当你的对手施放一个法术时，将该法术的一张复制置入你的手牌，其法力值消耗变为（0）点。",
    "<b>Secret:</b> When your opponent casts a spell, add a copy to your hand that costs (0)."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41158
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_024 : SimTemplate //* Mana Bind
    {
        //Secret: When your opponent casts a spell, add a copy to your hand that costs (0).

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            p.drawACard(SimCard.None, ownplay, true);
        }
    }
}