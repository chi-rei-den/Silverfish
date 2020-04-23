

/* _BEGIN_TEMPLATE_
{
  "id": "AT_109",
  "name": [
    "银色警卫",
    "Argent Watchman"
  ],
  "text": [
    "无法攻击。\n<b>激励：</b>在本回合中可正常进行攻击。",
    "Can't attack.\n<b>Inspire:</b> Can attack as normal this turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2505
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_109 : SimTemplate //* Argent Watchman
    {
        //Can't Attack. Inspire: Can attack as normal this turn.

        public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own)
            {
                m.cantAttack = false;
                m.updateReadyness();
            }
        }

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                if (!triggerEffectMinion.silenced)
                {
                    triggerEffectMinion.cantAttack = true;
                }
            }
        }
    }
}